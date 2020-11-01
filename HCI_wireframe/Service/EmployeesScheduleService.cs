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
using System.Dynamic;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace Class_diagram.Service
{
    public class EmployeesScheduleService : BingPath, IService<Schedule>
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
            employeesScheduleRepository.Delete(schedule.id);
        }

        public List<Schedule> GetAll()
        {
            return employeesScheduleRepository.GetAll();

        }

        private bool isScheduleForDoctor(Schedule schedule, DoctorUser doctor)
        {
            if (schedule.employeeid.Equals(doctor.id.ToString())) return true;
            return false;
        }

        private Shift getScheduleShiftForDoctor(DoctorUser doctor, string date, Schedule schedule)
        {
            if (isScheduleForDoctor(schedule, doctor) && schedule.date.Equals(date)) return schedule.shift;
            
            return null;
        }

        public Shift getShiftForDoctorForSpecificDay(string date, DoctorUser doctor)
        {
            List<Schedule> listOfSchedule = employeesScheduleRepository.GetAll();

            foreach (Schedule schedule in listOfSchedule)
            {
                Shift scheduleShiftForDoctor = getScheduleShiftForDoctor(doctor, date, schedule);
                if (scheduleShiftForDoctor != null) return scheduleShiftForDoctor;
            }

            return null;
        }

        public Boolean isTimeInGoodFormat(string start, string end)
        {
            if (!Regex.Match(start, "^[0-9]{2}:[0-9]{2}$").Success || !Regex.Match(end, "^[0-9]{2}:[0-9]{2}$").Success) return false;
            
            String[] startParts = start.Split(':');
            String[] endParts = end.Split(':');
         
            if (int.Parse(startParts[0]) > 23 || int.Parse(startParts[1]) > 60 || int.Parse(endParts[0]) > 23 || int.Parse(endParts[1]) > 60 || int.Parse(startParts[0]) > int.Parse(endParts[0])) return false;
            
            return true;
        }

        public bool isDoctorWorkingAtSpecifiedTime(string date, DoctorUser doctor, TimeSpan time)
        {
            Shift shift = getShiftForDoctorForSpecificDay(date, doctor);
        
            int areSelectedTimeAndStartTimeOfShiftEqual = TimeSpan.Compare(time, getStartTime(shift.startTime));
            int areSelectedTimeAndEndTimeOfShiftEqual = TimeSpan.Compare(time, getEndTime(shift.endTime));

            if ((areSelectedTimeAndStartTimeOfShiftEqual == 1 && areSelectedTimeAndEndTimeOfShiftEqual == -1) || areSelectedTimeAndStartTimeOfShiftEqual == 0) return true;
            
            return false;
        }

        private TimeSpan getEndTime(string endTime)
        {
            String[] endParts = endTime.Split(':');
            return new TimeSpan(int.Parse(endParts[0]), int.Parse(endParts[1]), int.Parse("00"));
        }

        private TimeSpan getStartTime(string startTime)
        {
            String[] startParst = startTime.Split(':');
            return new TimeSpan(int.Parse(startParst[0]), int.Parse(startParst[1]), int.Parse("00"));
        }

        public Schedule GetByid(int id)
        {
            return employeesScheduleRepository.GetByid(id);
        }
    }
}