/***********************************************************************
 * Module:  RegularAppointmentService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.RegularAppointmentService
 ***********************************************************************/
using Castle.Core.Internal;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.Contoller;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using HealthClinic.CL.Utility;

namespace HealthClinic.CL.Service
{
    public class RegularAppointmentService : BingPath, IStrategyAppointment
    {
        private IAppointmentRepository _appointmentRepository;
        public DoctorController doctorController;
        public EmployeesScheduleController employeesScheduleController;
        public PatientController patientController;
        String path = bingPathToAppDir(@"JsonFiles\appointments.json");

        public RegularAppointmentService(IAppointmentRepository appointmentRepository)
        {
            this._appointmentRepository = appointmentRepository;
            doctorController = new DoctorController();
            employeesScheduleController = new EmployeesScheduleController();
            patientController = new PatientController();
        }

        public List<DoctorAppointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        public void New(DoctorAppointment appointment, Operation operation)
        {
            _appointmentRepository.New(appointment);
        }

        public void Update(DoctorAppointment appointment, Operation operation)
        {
            _appointmentRepository.Update(appointment);
        }
        public void Remove(int appointmentid)
        {
            _appointmentRepository.Delete(appointmentid);
        }

        public DoctorAppointment GetByid(int id)
        {
            return _appointmentRepository.GetByid(id);
        }

        public List<DoctorAppointment> GetAppointmentsForPatient(int id)
        {
            return _appointmentRepository.GetAppointmentsForPatient(id);
        }

        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime date1, DateTime date2, PatientUser patient)
        {
            TimeSpan time1 = TimeSpan.FromMinutes(15);
            for (var date = date1; date <= date2; date = date.AddDays(1))
            {
                if (getAvailableTerm(doctor, date, time1, patient) != null) return getAvailableTerm(doctor, date, time1, patient);
            }
            return null;
        }


        private DoctorAppointment getAvailableTerm(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient)
        {
            Shift doctorShift = employeesScheduleController.getShiftForDoctorForSpecificDay(makeStringFromDate(date), doctor);

            if (doctorShift != null && doctorShift.startTime != null && doctorShift.endTime != null)
                return getNewDoctorAppointment(doctor, date, time1, patient, doctorShift);

            return null;
        }

        private DoctorAppointment getNewDoctorAppointment(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient, Shift doctorShift)
        {
            for (var time = getStartTimeSpan(doctorShift); time <= getEndTimeSpan(doctorShift); time = time.Add(time1))
            {
                if (isTermNotAvailable(doctor, time, makeStringFromDate(date), patient) == false)
                {
                    return new DoctorAppointment(0, time, makeStringFromDate(date), patient, doctor, null, doctor.ordination);
                }
            }
            return null;
        }

        private string makeStringFromDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        private TimeSpan getStartTimeSpan(Shift doctorShift)
        {
            return new TimeSpan(getHourStart(doctorShift), getMinutesStart(doctorShift), int.Parse("00"));
        }

        private TimeSpan getEndTimeSpan(Shift doctorShift)
        {
            return new TimeSpan(getHourEnd(doctorShift), getMinutesEnd(doctorShift), int.Parse("00"));
        }
        private int getHourStart(Shift doctorShift)
        {
            String[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[0]);
        }

        private int getMinutesStart(Shift doctorShift)
        {
            String[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[1]);
        }
        private int getHourEnd(Shift doctorShift)
        {
            String[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[0]);
        }

        private int getMinutesEnd(Shift doctorShift)
        {
            String[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[1]);
        }

        public DoctorAppointment recommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient)
        {
            List<DoctorUser> doctorsList = doctorController.GetAll();

            foreach (DoctorUser doctor in doctorsList)
            {
                if (doctor.isSpecialist == false && RecommendAnAppointment(doctor, date1, date2, patient) != null)
                    return RecommendAnAppointment(doctor, date1, date2, patient);
            }
            return null;
        }

        public Boolean isTermNotAvailable(DoctorUser doctor, TimeSpan time, String dateToString, PatientUser patient)
        {
            Boolean hasAppointmentDoctor = doctorController.doesDoctorHaveAnAppointmentAtSpecificTime(doctor, time, dateToString);
            Boolean hasOperationDoctor = doctorController.doesDoctorHaveAnOperationAtSpecificTime(doctor, time, dateToString);
           
            if (hasAppointmentDoctor == true || hasOperationDoctor == true ) return true;

            return false;
        }

        public List<DoctorAppointment> SimpleSearchAppointments(AppointmentReportSearchDto appointmentReportSearchDto)
        {
            return SearchForAppointmentType(SearchForDoctorNameAndSurname(SearchForDate(GetAppointmentsForPatient(appointmentReportSearchDto.PatientId), appointmentReportSearchDto), appointmentReportSearchDto), appointmentReportSearchDto);
        }

        private List<DoctorAppointment> SearchForDoctorNameAndSurname(List<DoctorAppointment> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.DoctorNameAndSurname))
            {
                appointments = appointments.FindAll(appointment => appointment.Doctor.firstName.Contains(appointmentSearchDto.DoctorNameAndSurname) || appointment.Doctor.secondName.Contains(appointmentSearchDto.DoctorNameAndSurname));
            }
            return appointments;
        }

        private List<DoctorAppointment> SearchForDate(List<DoctorAppointment> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsBetweenDates(appointmentSearchDto.Start, appointmentSearchDto.End, appointments);
            }
            else if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && !UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsBeforeDate(appointmentSearchDto.End, appointments);
            }
            else if(!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.Start) && UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.End))
            {
                appointments = GetAppointmentsAfterDate(appointmentSearchDto.Start, appointments);
            }
            return appointments;

        }

        private List<DoctorAppointment> GetAppointmentsBetweenDates(String start, String end, List<DoctorAppointment> appointments)
        {
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(start);
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(end);
            return appointments.FindAll(appointment => startDate <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= endDate);
        }

        private List<DoctorAppointment> GetAppointmentsBeforeDate(String date, List<DoctorAppointment> appointments)
        {
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(date);
            return appointments.FindAll(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= endDate);
        }

        private List<DoctorAppointment> GetAppointmentsAfterDate(String date, List<DoctorAppointment> appointments)
        {
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(date);
            return appointments.FindAll(appointment => startDate <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date));
        }

        private List<DoctorAppointment> SearchForAppointmentType(List<DoctorAppointment> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.AppointmentType) || CheckIfAppointment(appointmentSearchDto.AppointmentType))
            {
                return appointments;
            }
            return new List<DoctorAppointment>();
        }

        private Boolean CheckIfAppointment(String stringToCheck)
        {
            return stringToCheck.Equals("Appointment");
        }

    }
}