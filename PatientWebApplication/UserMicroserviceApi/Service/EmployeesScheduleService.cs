/***********************************************************************
 * Module:  EmployeesSchedule.cs
 * Author:  Luna
 * Purpose: Definition of the Class Service.EmployeesSchedule
 ***********************************************************************/

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;

namespace UserMicroserviceApi.Service
{
    public class EmployeesScheduleService
    {
        public IEmployeesScheduleRepository _employeesScheduleRepository;


        public EmployeesScheduleService(IEmployeesScheduleRepository employeesScheduleRepository)
        {
            _employeesScheduleRepository = employeesScheduleRepository;
        }

        public void New(Schedule schedule)
        {
            _employeesScheduleRepository.New(schedule);

        }

        public void Update(Schedule schedule)
        {
            _employeesScheduleRepository.Update(schedule);
        }

        public void Remove(Schedule schedule)
        {
            _employeesScheduleRepository.Delete(schedule.Id);
        }

        public List<Schedule> GetAll()
        {
            return _employeesScheduleRepository.GetAll();
        }

        private bool IsScheduleForDoctor(Schedule schedule, DoctorUser doctor)
        {
            return schedule.EmployeeId == doctor.Id;
        }

        private Shift GetScheduleShiftForDoctor(DoctorUser doctor, string date, Schedule schedule)
        {
            return IsScheduleForDoctor(schedule, doctor) && schedule.Date.Equals(date) ? schedule.Shift : null;
        }

        public Shift GetShiftForDoctorForSpecificDay(string date, DoctorUser doctor)
        {
            if (doctor == null)
            {
                return null;
            }
            foreach (Schedule schedule in _employeesScheduleRepository.GetAll())
            {
                if(GetScheduleShiftForDoctor(doctor, date, schedule) != null) return GetScheduleShiftForDoctor(doctor, date, schedule);
            }
            return null;
        }

        public bool IsTimeInGoodFormat(string start, string end)
        {
            if (!Regex.Match(start, "^[0-9]{2}:[0-9]{2}$").Success || !Regex.Match(end, "^[0-9]{2}:[0-9]{2}$").Success) return false;

            string[] startParts = start.Split(':');
            string[] endParts = end.Split(':');

            if (int.Parse(startParts[0]) > 23 || int.Parse(startParts[1]) > 60 || int.Parse(endParts[0]) > 23 || int.Parse(endParts[1]) > 60 || int.Parse(startParts[0]) > int.Parse(endParts[0])) return false;

            return true;
        }

        public bool IsDoctorWorkingAtSpecifiedTime(string date, DoctorUser doctor, TimeSpan time)
        {
            Shift shift = GetShiftForDoctorForSpecificDay(date, doctor);

            int areSelectedTimeAndStartTimeOfShiftEqual = TimeSpan.Compare(time, GetStartTime(shift.StartTime));
            int areSelectedTimeAndEndTimeOfShiftEqual = TimeSpan.Compare(time, GetEndTime(shift.EndTime));

            if (areSelectedTimeAndStartTimeOfShiftEqual == 1 && areSelectedTimeAndEndTimeOfShiftEqual == -1 || areSelectedTimeAndStartTimeOfShiftEqual == 0) return true;

            return false;
        }

        private TimeSpan GetEndTime(string endTime)
        {
            string[] endParts = endTime.Split(':');
            return new TimeSpan(int.Parse(endParts[0]), int.Parse(endParts[1]), int.Parse("00"));
        }

        private TimeSpan GetStartTime(string startTime)
        {
            string[] startParst = startTime.Split(':');
            return new TimeSpan(int.Parse(startParst[0]), int.Parse(startParst[1]), int.Parse("00"));
        }

        public Schedule GetByid(int id)
        {
            return _employeesScheduleRepository.GetByid(id);
        }
    }
}