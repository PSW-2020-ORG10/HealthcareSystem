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
        private DoctorService doctorService;
        private EmployeesScheduleService employeesScheduleService;
        private IPatientsRepository _patientRepository;
        private OperationService operationService;
        String path = bingPathToAppDir(@"JsonFiles\appointments.json");

        public RegularAppointmentService(IAppointmentRepository appointmentRepository, IEmployeesScheduleRepository employeesScheduleRepository, DoctorService doctorService, IPatientsRepository patientRepository, OperationService operationService)
        {
            this._appointmentRepository = appointmentRepository;
            this.doctorService = doctorService;
            this.employeesScheduleService = new EmployeesScheduleService(employeesScheduleRepository);
            this._patientRepository = patientRepository;
            this.operationService = operationService;
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
            if (!GetAllAvailableAppointmentsForDate(appointment.Date, appointment.DoctorUserId, appointment.PatientUserId).Contains(appointment)) return;
            _appointmentRepository.New(appointment);
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to create new appointment. </summary>
        /// <param name="appointment"><c>appointment</c> is appointment we want to create.</param>
        /// <returns> Created appointment. </returns>
        public DoctorAppointment CreateRecommended(DoctorAppointment appointment)
        {
            return _appointmentRepository.Create(appointment);
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

        public List<DoctorAppointment> GetAppointmentsForDoctor(int id)
        {
            List<DoctorAppointment> appointments = _appointmentRepository.GetAppointmentsForDoctor(id);
            return appointments;
        }

        public List<DoctorAppointment> GetRecommendedAppointment(RecommendedAppointmentDto dto)
        {
            DoctorUser doctor = doctorService.GetByid(dto.DoctorId);
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(dto.Start);
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(dto.End);
            PatientUser patient = _patientRepository.Find(2); //still no login, change after login, id set to 1
            List<DoctorAppointment> recomendedAppointments = GetAllAvailableAppointmentsForRecommendedDates(dto.DoctorId, startDate, endDate, patient.id);

            if (!recomendedAppointments.Any())
            {
                if (dto.Priority.Equals("doctor"))
                {
                    endDate = (endDate - startDate).TotalDays > 20 ? endDate.AddDays(10) : (endDate - startDate).TotalDays > 10 ? endDate.AddDays(5) : endDate.AddDays(3);

                    recomendedAppointments = GetAllAvailableAppointmentsForRecommendedDates(dto.DoctorId, startDate, endDate, patient.id);
                }
                else
                {
                    recomendedAppointments = RecommenedAnAppointmentDatePriority(startDate, endDate, patient, doctor.speciality);
                }
            }

            return recomendedAppointments;
        }

        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime startDate, DateTime endDate, PatientUser patient)
        {
            TimeSpan time1 = TimeSpan.FromMinutes(15);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (GetAvailableTerm(doctor, date, time1, patient) != null) return GetAvailableTerm(doctor, date, time1, patient);
            }
            return null;
        }

        public List<DoctorAppointment> GetAllAvailableAppointmentsForRecommendedDates(int doctorId, DateTime startDate, DateTime endDate, int patientId)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                List<TimeSpan> startTimesAppointments = GetAllStartTimes(CreateAppointmentSetForDate(date, doctorId, patientId).ToList());
                
                Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(MakeStringFromDate(date), doctorService.GetByid(doctorId));
                if (doctorShift == null)
                {
                    continue;
                }
                TimeSpan time = TimeSpan.Parse(doctorShift.startTime);
                while (time != TimeSpan.Parse(doctorShift.endTime))
                {
                    if (!startTimesAppointments.Contains(time) && !IsTermNotAvailable(doctorService.GetByid(doctorId), time, MakeStringFromDate(date), _patientRepository.Find(patientId)))
                    {
                        availableAppointments.Add((new DoctorAppointment(0, time, MakeStringFromDate(date), _patientRepository.Find(patientId), doctorService.GetByid(doctorId), new List<Referral>(), doctorService.GetByid(doctorId).ordination)));
                        if (availableAppointments.Count >= 5)
                        {
                            return availableAppointments;
                        }
                    }
                    time = time.Add(TimeSpan.FromMinutes(15));
                }
            }

            return availableAppointments;
        }

        private List<DoctorAppointment> GetAllAppointmentsByDateAndDoctor(DateTime date, int doctorId)
        {
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();
            foreach (DoctorAppointment appointment in GetAppointmentsForDoctor(doctorId))
            {
                if(date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        private List<DoctorAppointment> GetAllAppointmentsByDateAndPatient(DateTime date, int patientId)
        {
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();
            foreach (DoctorAppointment appointment in GetAppointmentsForPatient(patientId))
            {
                if (date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date))
                {
                    appointments.Add(appointment);
                }
            }
            return appointments;
        }

        private DoctorAppointment GetAvailableTerm(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient)
        {
            Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(MakeStringFromDate(date), doctor);

            if (doctorShift != null && doctorShift.startTime != null && doctorShift.endTime != null)
                return GetNewDoctorAppointment(doctor, date, time1, patient, doctorShift);

            return null;
        }

        public List<DoctorAppointment> GetAllAvailableAppointmentsForDate(string dateString, int doctorId, int patientId)
        {
            DateTime date = UtilityMethods.ParseDateInCorrectFormat(dateString);
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            List<TimeSpan> startTimesAppointments = GetAllStartTimes(CreateAppointmentSetForDate(date, doctorId, patientId).ToList());
            List<Operation> operations = operationService.CreateOperationtSetForDate(date, doctorId, patientId).ToList();
            Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(dateString, doctorService.GetByid(doctorId));
            if(doctorShift == null)
            {
                return availableAppointments;
            }
            TimeSpan time = TimeSpan.Parse(doctorShift.startTime);
            while (time != TimeSpan.Parse(doctorShift.endTime)){
                if (!startTimesAppointments.Contains(time) && !operationService.IsOperationInTimePeriod(time, operations))
                {
                    availableAppointments.Add(new DoctorAppointment(0, time, dateString, patientId, doctorId, new List<Referral>(), doctorService.GetByid(doctorId).ordination));
                }
                time = time.Add(TimeSpan.FromMinutes(15));
            }
            return availableAppointments;
        }

        private HashSet<DoctorAppointment> CreateAppointmentSetForDate(DateTime date, int doctorId, int patientId)
        {
            HashSet<DoctorAppointment> appointmentsSet = new HashSet<DoctorAppointment>(GetAllAppointmentsByDateAndDoctor(date, doctorId));
            appointmentsSet.UnionWith(GetAllAppointmentsByDateAndPatient(date, patientId));
            return appointmentsSet;
        }

        private List<TimeSpan> GetAllStartTimes(List<DoctorAppointment> appointments)
        {
            List <TimeSpan> startTimes = new List<TimeSpan>();
            foreach (DoctorAppointment appointment in appointments)
            {
                startTimes.Add(appointment.Start);
            }
            return startTimes;
        }

        private DoctorAppointment GetNewDoctorAppointment(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient, Shift doctorShift)
        {
            for (var time = GetStartTimeSpan(doctorShift); time < GetEndTimeSpan(doctorShift); time = time.Add(time1))
            {
                if (IsTermNotAvailable(doctor, time, MakeStringFromDate(date), patient) == false)
                {
                    return new DoctorAppointment(0, time, MakeStringFromDate(date), patient, doctor, null, doctor.ordination);
                }
            }
            return null;
        }

        private string MakeStringFromDate(DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        private TimeSpan GetStartTimeSpan(Shift doctorShift)
        {
            return new TimeSpan(GetHourStart(doctorShift), GetMinutesStart(doctorShift), int.Parse("00"));
        }

        private TimeSpan GetEndTimeSpan(Shift doctorShift)
        {
            return new TimeSpan(GetHourEnd(doctorShift), GetMinutesEnd(doctorShift), int.Parse("00"));
        }
        private int GetHourStart(Shift doctorShift)
        {
            String[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[0]);
        }

        private int GetMinutesStart(Shift doctorShift)
        {
            String[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[1]);
        }
        private int GetHourEnd(Shift doctorShift)
        {
            String[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[0]);
        }

        private int GetMinutesEnd(Shift doctorShift)
        {
            String[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[1]);
        }

        public List<DoctorAppointment> RecommenedAnAppointmentDatePriority(DateTime date1, DateTime date2, PatientUser patient, string speciality)
        {
            List<DoctorUser> doctorsList = doctorService.GetAll();
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();

            foreach (DoctorUser doctor in doctorsList)
            {
                if (doctor.speciality.Equals(speciality) && GetAllAvailableAppointmentsForRecommendedDates(doctor.id, date1, date2, patient.id).Any())
                    return GetAllAvailableAppointmentsForRecommendedDates(doctor.id, date1, date2, patient.id);
            }
            return appointments;
        }

        public Boolean IsTermNotAvailable(DoctorUser doctor, TimeSpan time, String dateToString, PatientUser patient)
        {
            Boolean hasAppointmentDoctor = doctorService.DoesDoctorHaveAnAppointmentAtSpecificTime(doctor, time, dateToString);
            Boolean hasOperationDoctor = doctorService.DoesDoctorHaveAnOperationAtSpecificTime(doctor, time, dateToString);
           
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

        /// <summary> This method is getting lists of <c>DoctorAppointment</c> and <c>Survey</c> and checks for all valid appointment. </summary>
        /// <param name="allValidAppointments"><c>appointments</c> is empty List of valid appointments. </param>
        /// <param name="surveys"><c>surveys</c> is List of all surveys </param>
        /// <returns> List of valid appointments. </returns>
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