/***********************************************************************
 * Module:  EmployeesSchedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EmployeesSchedule
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using Class_diagram.Repository;
using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Service;
using Klinika;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace Class_diagram.Service
{
   public class EmployeesScheduleService : bingPath, IService<Schedule>
    {
        public EmployeesScheduleRepository employeesScheduleRepository;
        String path = bingPathToAppDir(@"JsonFiles\schedule.json");


        public EmployeesScheduleService()
        {
            employeesScheduleRepository = new EmployeesScheduleRepository(path);
        }

        public void New(Schedule schedule)
        {
            employeesScheduleRepository.New(schedule);

        }

        public void Update(Schedule schedule)
        {
            employeesScheduleRepository.Update(schedule);
        }
      
        public void Remove(Schedule schedule)
        {
            employeesScheduleRepository.Delete(schedule.ID);
        }
      
        public List<Schedule> GetAll()
        {
            return employeesScheduleRepository.GetAll();

        }
        public Shift getShiftForDoctorForSpecificDay(string date, DoctorUser doctor)
        {
            List<Schedule> listOfSchedule = employeesScheduleRepository.GetAll();
          
            foreach (Schedule schedule in listOfSchedule)
            {
                if (schedule.employeeID.Equals(doctor.ID.ToString()))
                {
                    if (schedule.Date.Equals(date))
                    {
                        return schedule.shift;

                    }
                }
            }
            return null;
        }

        public Boolean isTimeInGoodFormat(string start, string end)
        {
            if(!Regex.Match(start, "^[0-9]{2}:[0-9]{2}$").Success || !Regex.Match(end, "^[0-9]{2}:[0-9]{2}$").Success) {
                return false;
            }

            String[] startParts = start.Split(':');
            String[] endParts = end.Split(':');
            int startIntPart1 = int.Parse(startParts[0]);
            int startIntPart2 = int.Parse(startParts[1]);
            int ensIntPart1 = int.Parse(endParts[0]);
            int endtIntPart2 = int.Parse(endParts[1]);

           
            if(startIntPart1 > 23 || startIntPart2 > 60 || ensIntPart1>23 || endtIntPart2>60 || startIntPart1> ensIntPart1)
            {
                return false;
            }


            return true;
        }

        public bool isDoctorWorkingAtSpecifiedTime(string date, DoctorUser doctor, TimeSpan time)
        {
            Shift shift = getShiftForDoctorForSpecificDay(date, doctor);
            String pocetak = shift.StartTime;
            String kraj = shift.EndTime;
            String[] deloviPocetak = pocetak.Split(':');
            String[] deloviKraj = kraj.Split(':');

            TimeSpan pocetakTime = new TimeSpan(int.Parse(deloviPocetak[0]), int.Parse(deloviPocetak[1]), int.Parse("00"));
            TimeSpan krajTime = new TimeSpan(int.Parse(deloviKraj[0]), int.Parse(deloviKraj[1]), int.Parse("00"));
            int result3 = TimeSpan.Compare(time, pocetakTime);
            int result4 = TimeSpan.Compare(time, krajTime);

            if ((result3 == 1 && result4 == -1) || result3 ==0)
            {
               return true;
            }

            return false;
        }

        public Schedule GetByID(int ID)
        {
           return employeesScheduleRepository.GetByID(ID);
        }
    }
}