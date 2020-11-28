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
using System.Linq;

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

        /// <summary> This method is calling <c>AppointmentRepository</c> to get list of all appointments. </summary>
        /// <returns> List of all appointments. </returns>
        public List<DoctorAppointment> GetAll()
        {
            return _appointmentRepository.GetAll();
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to create new appointment. </summary>
        /// <param name="appointment"><c>appointment</c> is appointment we want to create.</param>
        /// <returns> Created appointment. </returns>
        public void New(DoctorAppointment appointment, Operation operation)
        {
            _appointmentRepository.New(appointment);
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to update appointment. </summary>
        /// <param name="appointment"><c>appointment</c> is appointment we want to update.</param>
        /// <returns> Updated appointment. </returns>
        public void Update(DoctorAppointment appointment, Operation operation)
        {
            _appointmentRepository.Update(appointment);
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to remove appointment. </summary>
        /// <param name="appointmentid"><c>appointmentid</c> is id of appointment we want to delete.</param>
        /// <returns> Removed appointment. </returns>
        public void Remove(int appointmentid)
        {
            _appointmentRepository.Delete(appointmentid);
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to get appointment by it's id. </summary>
        /// <param name="id"><c>id</c> is id of appointment we need.</param>
        /// <returns> One appointment. </returns>
        public DoctorAppointment GetByid(int id)
        {
            return _appointmentRepository.GetByid(id);
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to get all appointments of one patient. </summary>
        /// <param name="id"><c>id</c> is id of patient who's appointments we need.</param>
        /// <returns> List of patient's appointments. </returns>
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

        /// <summary> This method is calling SearchForAppointmentType, SearchForDoctorNameAndSurname, SearchForDate to get list of filtered <c>DoctorAppointment</c> of one patient. </summary>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter appointments.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        public List<DoctorAppointment> SimpleSearchAppointments(AppointmentReportSearchDto appointmentReportSearchDto)
        {
            return SearchForAppointmentType(SearchForDoctorNameAndSurname(SearchForDate(GetAppointmentsForPatient(appointmentReportSearchDto.PatientId), appointmentReportSearchDto), appointmentReportSearchDto), appointmentReportSearchDto);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by doctor's name and surname. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<DoctorAppointment> SearchForDoctorNameAndSurname(List<DoctorAppointment> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.DoctorNameAndSurname))
            {
                appointments = appointments.FindAll(appointment => appointment.Doctor.firstName.Contains(appointmentSearchDto.DoctorNameAndSurname) || appointment.Doctor.secondName.Contains(appointmentSearchDto.DoctorNameAndSurname));
            }
            return appointments;
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by date. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentReportSearchDto"><c>appointmentReportSearchDto</c> is Data Transfer Object of a <c>Operation</c> that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
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

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are between two dates. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="start"><c>start</c> is first date of search.
        /// </param>
        /// <param name="end"><c>end</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<DoctorAppointment> GetAppointmentsBetweenDates(String start, String end, List<DoctorAppointment> appointments)
        {
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(start);
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(end);
            return appointments.FindAll(appointment => startDate <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= endDate);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are before given date. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is last date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<DoctorAppointment> GetAppointmentsBeforeDate(String date, List<DoctorAppointment> appointments)
        {
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(date);
            return appointments.FindAll(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) <= endDate);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient that are after given date. </summary>
        /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="date"><c>date</c> is first date of search.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<DoctorAppointment> GetAppointmentsAfterDate(String date, List<DoctorAppointment> appointments)
        {
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(date);
            return appointments.FindAll(appointment => startDate <= UtilityMethods.ParseDateInCorrectFormat(appointment.Date));
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of one patient by appointment type. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <param name="appointmentSearchDto"><c>appointmentSearchDto</c> is Data Transfer Object that is being used to filter operations.
        /// </param>
        /// <returns> List of filtered patient's appointments. </returns>
        private List<DoctorAppointment> SearchForAppointmentType(List<DoctorAppointment> appointments, AppointmentReportSearchDto appointmentSearchDto)
        {
            if (UtilityMethods.CheckIfStringIsEmpty(appointmentSearchDto.AppointmentType) || CheckIfAppointment(appointmentSearchDto.AppointmentType))
            {
                return appointments;
            }
            return new List<DoctorAppointment>();
        }

        /// <summary> This method is checks if given string equals appointment. </summary>
        /// <param name="stringToCheck"><c>stringToCheck</c> is string that needs to be checked.
        /// </param>
        /// <returns> <c>true</c> if string equals Appointment; otherwise returns <c>false</c>. </returns>
        private Boolean CheckIfAppointment(String stringToCheck)
        {
            return stringToCheck.Equals("Appointment");
        }

        /// <summary> This method is calling searchForFirstParameter, searchForOtherParameters to get list of filtered <c>DoctorAppointment</c> of logged patient. </summary>
        /// /// <param name="dto"><c>AppointmentAdvancedSearchDto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that is be used to filter appointments.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        public List<DoctorAppointment> AdvancedSearchAppointments(AppointmentAdvancedSearchDto dto)
        {

            return SearchForOtherParameters(GetAppointmentsForPatient(2), dto, SearchForFirstParameter(GetAppointmentsForPatient(2), dto));

        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> that match list of parameters in <c>AppointmentAdvnacedSearchDto</c></summary>
        /// <param name="appointments"> List of all <c>DoctorAppointment</c> of logged user.
        /// </param>
        /// <param name="dto"><c>AppointmentAdvancedSearchDto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that is be used to filter appointments.
        /// </param>
        /// <param name="firstAppointments"> List of <c>DoctorAppointment</c> that contains appointments that matches first parameter.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<DoctorAppointment> SearchForOtherParameters(List<DoctorAppointment> appointments, AppointmentAdvancedSearchDto dto, List<DoctorAppointment> firstAppointments)
        {
            for (int i = 0; i < dto.RestRoles.Length; i++)
            {   
                firstAppointments = SearchForLogicOperators(dto.LogicOperators[i], SearchForOtherRoles(dto.RestRoles[i], dto.Rest[i], appointments), firstAppointments);
            }
            return firstAppointments;
        }

        private List<DoctorAppointment> SearchForLogicOperators(string logicOperator, List<DoctorAppointment> othersAppointments, List<DoctorAppointment> finalAppointments)
        {
            return logicOperator.Equals("or") ? othersAppointments.Union(finalAppointments).ToList() : othersAppointments.Intersect(finalAppointments).ToList();
        }

        private List<DoctorAppointment> SearchForOtherRoles(string otherParameter, string otherValue, List<DoctorAppointment> appointments)
        {
            return otherParameter.Equals("doctor") ? SearchForDoctorAdvanced(appointments, otherValue) :
               otherParameter.Equals("date") ? SearchForDateAdvanced(appointments, otherValue) :
               SearchForRoomAdvanced(appointments, otherValue);
        }

        private List<DoctorAppointment> SearchForFirstParameter(List<DoctorAppointment> appointments, AppointmentAdvancedSearchDto dto)
        {
            return dto.FirstRole.Equals("doctor") || UtilityMethods.CheckIfStringIsEmpty(dto.FirstRole) ? SearchForDoctorAdvanced(appointments, dto.First) :
                dto.FirstRole.Equals("date") ? SearchForDateAdvanced(appointments, dto.First) : SearchForRoomAdvanced(appointments, dto.First);
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Doctor</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<DoctorAppointment> SearchForDoctorAdvanced(List<DoctorAppointment> appointments, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment => appointment.Doctor.firstName.Contains(searchField) || appointment.Doctor.secondName.Contains(searchField) || appointment.Doctor.DoctorFullName().Contains(searchField));
            }
            return appointments;
        }

        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Date</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<DoctorAppointment> SearchForDateAdvanced(List<DoctorAppointment> appointments, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment=> appointment.Date.ToString().Equals(searchField));
            }
            return appointments;
        }
        
        /// <summary> This method is getting list of filtered <c>DoctorAppointment</c> of logged patient by parameter <c>Room</c>. </summary>
        /// /// <param name="appointments"><c>appointments</c> is List of appointments that matches search fields.
        /// </param>
        /// <returns> List of filtered appointments. </returns>
        private List<DoctorAppointment> SearchForRoomAdvanced(List<DoctorAppointment> appointments, String searchField)
        {
            if (!UtilityMethods.CheckIfStringIsEmpty(searchField))
            {
                appointments = appointments.FindAll(appointment => appointment.RoomId.Contains(searchField));
            }
            return appointments;
        }       

        public List<DoctorAppointment> FindAllValidAppointments(List<DoctorAppointment> allValidAppointments, List<Survey> surveys)
        {
            return CheckIfAppointmentsHappened(allValidAppointments.Where(p => !FindAllUnvalidAppointments(surveys).Any(p2 => p2 == p.id)).ToList());
        }

        private static List<int> FindAllUnvalidAppointments(List<Survey> allSurveys)
        {
            List<int> allUnvalidAppointments = new List<int>();
            foreach (Survey survey in allSurveys)
            {
                allUnvalidAppointments.Add(survey.appointmentId);
            }
            return allUnvalidAppointments;
        }

        private List<DoctorAppointment> CheckIfAppointmentsHappened(List<DoctorAppointment> allValidAppointments)
        {
            return allValidAppointments.Where(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < DateTime.Now).ToList();
        }
    }
}