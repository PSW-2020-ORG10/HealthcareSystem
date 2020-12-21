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
using HealthClinic.CL.DbContextModel;

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

        public RegularAppointmentService(MyDbContext context)
        {
            this._appointmentRepository = new AppointmentRepository(context);
            this._patientRepository = new PatientsRepository(context);
            this.operationService = new OperationService(new OperationRepository(context));
            this.employeesScheduleService = new EmployeesScheduleService(new EmployeesScheduleRepository(context));
            this.doctorService = new DoctorService(new OperationRepository(context), _appointmentRepository, new EmployeesScheduleRepository(context), new DoctorRepository(context));
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

        public DoctorAppointment CreateRegular(DoctorAppointment appointment)
        {
            var appointments = GetAllAvailableAppointmentsForDate(appointment.Date, appointment.DoctorUserId, appointment.PatientUserId);
            if (!appointments.Contains(appointment)) return null;
            return _appointmentRepository.New(appointment);

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

        /// <summary> This method is calling <c>AppointmentRepository</c> to get all appointments of one patient that already happend . </summary>
        /// <param name="id"><c>id</c> is id of patient who's appointments we need.</param>
        /// <returns> List of patient's appointments. </returns>
        public List<DoctorAppointment> GetAppointmentsForPatient(int id)
        {
            return CheckIfAppointmentsHappened(_appointmentRepository.GetAppointmentsForPatient(id));
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to get all appointments of one patient that is happening in next 2 days . </summary>
        /// <param name="id"><c>id</c> is id of patient who's appointments we need.</param>
        /// <returns> List of patient's appointments. </returns>
        public List<DoctorAppointment> GetAppointmentsForPatientInTwoDays(int id)
        {
            return CheckIfAppointmentsAreInTwoDays(_appointmentRepository.GetAppointmentsForPatient(id));
        }

        /// <summary> This method is calling <c>AppointmentRepository</c> to get all appointments of one patient that is happening in future . </summary>
        /// <param name="id"><c>id</c> is id of patient who's appointments we need.</param>
        /// <returns> List of patient's appointments. </returns>
        public List<DoctorAppointment> GetAppointmentsForPatientInFuture(int id)
        {
            return CheckIfAppointmentsAreInFuture(_appointmentRepository.GetAppointmentsForPatient(id));
        }

        public List<DoctorAppointment> GetAppointmentsForDoctor(int id)
        {
            return _appointmentRepository.GetAppointmentsForDoctor(id);
        }

        /// <summary> This method is getting List of <c>DoctorAppointment</c> that matches recoomended filters </summary>
        /// <param name="dto"><c>RecommendedAppointmentDto</c> is Data Transfer Object that is being used to get Recommended Appointments</param>
        /// <returns> List of recommended appointments</returns>
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

        /// <summary> This method is getting List of <c>DoctorAppointment</c> when doctor and patient are available </summary>
        /// <param name="doctorId"><c>DoctorUser</c> id of doctor who will execute appointment</param>
        /// <param name="startDate">From which date we want to get recommended appointment</param>
        /// <param name="endDate">To which date we want to get recommended appointment</param>
        /// <param name="patientId"><c>PatientUser</c> id of patient that is scheduling appointment</param>
        /// <returns> List of recommended appointments</returns>
        public List<DoctorAppointment> GetAllAvailableAppointmentsForRecommendedDates(int doctorId, DateTime startDate, DateTime endDate, int patientId)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(MakeStringFromDate(date), doctorService.GetByid(doctorId));
                if (doctorShift == null)
                {
                    continue;
                }
                
                TimeSpan time = TimeSpan.Parse(doctorShift.startTime);

                availableAppointments = GetAvailableForFreeTime(time, availableAppointments, doctorShift, doctorId, date, patientId);       
            }

            return availableAppointments;
        }

        private List<DoctorAppointment> GetAvailableForFreeTime(TimeSpan time, List<DoctorAppointment> availableAppointments, Shift doctorShift, int doctorId, DateTime date, int patientId)
        {
            while (time != TimeSpan.Parse(doctorShift.endTime) && availableAppointments.Count < 5)
            {
                if (time < DateTime.Now.TimeOfDay && UtilityMethods.CheckIfDateIsToday(date))
                {
                    time = time.Add(TimeSpan.FromMinutes(15));
                    continue;
                }
                availableAppointments = GetListAvailableAppointments(availableAppointments, doctorId, time, date, patientId);
                time = time.Add(TimeSpan.FromMinutes(15));
            }
            return availableAppointments;
        }

        private List<DoctorAppointment> GetListAvailableAppointments(List<DoctorAppointment> availableAppointments, int doctorId, TimeSpan time, DateTime date, int patientId)
        {
            List<TimeSpan> startTimesAppointments = GetAllStartTimes(CreateAppointmentSetForDate(date, doctorId, patientId).ToList());
            List<Operation> operations = operationService.CreateOperationtSetForDate(date, doctorId, patientId).ToList();
            if ((!startTimesAppointments.Contains(time) && !operationService.IsOperationInTimePeriod(time, operations)) || availableAppointments.Count >= 5)
            {
                availableAppointments.Add((new DoctorAppointment(0, time, MakeStringFromDate(date), _patientRepository.Find(patientId), doctorService.GetByid(doctorId), new List<Referral>(), doctorService.GetByid(doctorId).ordination)));
            }

            return availableAppointments;
        }

        /// <summary> This method is getting all appointments of one doctor on given date. </summary>
        /// <returns> list of all doctor's appointments on specific date. </returns>
        private List<DoctorAppointment> GetAllAppointmentsByDateAndDoctor(DateTime date, int doctorId)
        {
            return GetAppointmentsForDoctor(doctorId).Where(appointment => (date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && !appointment.IsCanceled)).ToList();
        }

        /// <summary> This method is getting all appointments of one patient on given date. </summary>
        /// <returns> list of all patients's appointments on specific date. </returns>
        private List<DoctorAppointment> GetAllAppointmentsByDateAndPatient(DateTime date, int patientId)
        {
            return GetAppointmentsForPatient(patientId).Where(appointment => (date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && !appointment.IsCanceled)).ToList();
        }

        private DoctorAppointment GetAvailableTerm(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient)
        {
            Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(MakeStringFromDate(date), doctor);

            if (doctorShift != null && doctorShift.startTime != null && doctorShift.endTime != null)
                return GetNewDoctorAppointment(doctor, date, time1, patient, doctorShift);

            return null;
        }

        /// <summary> This method is getting all available appointments of one doctor and one patient on given date. </summary>
        /// <param name="dateString">Date for which this method get's all available appointments</param>
        /// <param name="doctorId">Id of doctor for whom this method get's all available appointments</param>
        /// <param name="patientId">Id of patient for whom this method get's all available appointments</param>
        /// <returns> list of all available appointments on specific date for given doctor and patient. </returns>
        public List<DoctorAppointment> GetAllAvailableAppointmentsForDate(string dateString, int doctorId, int patientId)
        {
            Shift doctorShift = employeesScheduleService.getShiftForDoctorForSpecificDay(dateString, doctorService.GetByid(doctorId));
            if (doctorShift == null)
            {
                return new List<DoctorAppointment>(); 
            }
            return CreateListOfAvailableAppointments(doctorShift, dateString, doctorId, patientId);
        }

        private List<DoctorAppointment> CreateListOfAvailableAppointments(Shift doctorShift, string dateString, int doctorId, int patientId)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            TimeSpan time = TimeSpan.Parse(doctorShift.startTime);
            while (time != TimeSpan.Parse(doctorShift.endTime))
            {   
                if(time < DateTime.Now.TimeOfDay && UtilityMethods.CheckIfDateIsToday(dateString))
                {
                    time = time.Add(TimeSpan.FromMinutes(15));
                    continue;
                }
                AddAppointments(time, availableAppointments, dateString, patientId, doctorId);
                time = time.Add(TimeSpan.FromMinutes(15));
            }
            return availableAppointments;
        }

        private void AddAppointments(TimeSpan time, List<DoctorAppointment> availableAppointments, string dateString, int patientId, int doctorId)
        {
            DateTime date = UtilityMethods.ParseDateInCorrectFormat(dateString);
            List<TimeSpan> startTimesAppointments = GetAllStartTimes(CreateAppointmentSetForDate(date, doctorId, patientId).ToList());
            List<Operation> operations = operationService.CreateOperationtSetForDate(date, doctorId, patientId).ToList();
            if (!startTimesAppointments.Contains(time) && !operationService.IsOperationInTimePeriod(time, operations))
            {
                availableAppointments.Add(new DoctorAppointment(0, time, dateString, patientId, doctorId, new List<Referral>(), doctorService.GetByid(doctorId).ordination));
            }
        }

        /// <summary> This method is creating a set out of list of doctor's and patient's apaintments on specific date. </summary>
        /// <returns> <c>HashSet</c> of appointments. </returns>
        private HashSet<DoctorAppointment> CreateAppointmentSetForDate(DateTime date, int doctorId, int patientId)
        {
            HashSet<DoctorAppointment> appointmentsSet = new HashSet<DoctorAppointment>(GetAllAppointmentsByDateAndDoctor(date, doctorId));
            appointmentsSet.UnionWith(GetAllAppointmentsByDateAndPatient(date, patientId));
            return appointmentsSet;
        }

        /// <summary> This method is getting List of Start Times of already scheduled <c>DoctorAppointment</c> </summary>
        /// <param name="appointments">List of <c>DoctorAppointment</c> that are already scheduled</param>
        /// <returns> List of start times for scheduled appointments</returns>
        private List<TimeSpan> GetAllStartTimes(List<DoctorAppointment> appointments)
        {
            List <TimeSpan> startTimes = new List<TimeSpan>();
            foreach (DoctorAppointment appointment in appointments)
            {
                if (!appointment.IsCanceled)
                {
                    startTimes.Add(appointment.Start);
                }
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

        /// <summary> This method is getting List of <c>DoctorAppointment</c> when priority is date </summary>
        /// <param name="startDate">From which date we want to get recommended appointment</param>
        /// <param name="endDate">To which date we want to get recommended appointment</param>
        /// <param name="patient"><c>PatientUser</c> who is scheduling appointment</param>
        /// <param name="speciality">Speciality of doctor which patient wanted first to execute appointment</param>
        /// <returns>List of <c>DoctorAppointment</c></returns>
        public List<DoctorAppointment> RecommenedAnAppointmentDatePriority(DateTime startDate, DateTime endDate, PatientUser patient, string speciality)
        {
            List<DoctorUser> doctorsList = doctorService.GetAll();
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();

            foreach (DoctorUser doctor in doctorsList)
            {
                if (doctor.speciality.Equals(speciality) && GetAllAvailableAppointmentsForRecommendedDates(doctor.id, startDate, endDate, patient.id).Any())
                    return GetAllAvailableAppointmentsForRecommendedDates(doctor.id, startDate, endDate, patient.id);
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
        public List<DoctorAppointment> FindAllValidAppointmentsWithoutSurvey(List<DoctorAppointment> allValidAppointments, List<Survey> surveys)
        {
            return CheckIfAppointmentsHappened(allValidAppointments.Where(validAppointment => !FindAllUnvalidAppointments(surveys).Any(unvalidAppointment => unvalidAppointment == validAppointment.id)).ToList());
        }

        public List<DoctorAppointment> FindAllValidAppointmentsWithSurvey(List<DoctorAppointment> allValidAppointments, List<Survey> surveys)
        {
            return CheckIfAppointmentsHappened(allValidAppointments.Where(validAppointment => FindAllUnvalidAppointments(surveys).Any(unvalidAppointment => unvalidAppointment == validAppointment.id)).ToList());
        }

        /// <summary> This method provides <c>DoctorAppointment</c> <paramref name="appointment"/> and sends it to <c>AppointmentRepository</c> there appointment.IsCanceled will be set to true. </summary>
        /// <param name="appointment"><c>DoctorAppointment</c> is <c>DoctorAppointment</c> that needs to be canceled.
        /// </param>
        /// <returns>null if DoctorAppointment is not valid; otherwise, succesfully canceled DoctorAppointment. </returns>
        public DoctorAppointment CancelAppointment(int appointmentId)
        {
            DoctorAppointment appointment = CheckIfAppointmentsAreInFutureFromToday(_appointmentRepository.GetByid(appointmentId));
            return (appointment == null) ? null : _appointmentRepository.CancelAppointment(appointment);
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
        private List<DoctorAppointment> CheckIfAppointmentsAreInTwoDays(List<DoctorAppointment> allValidAppointments)
        {
            return allValidAppointments.Where(appointment => ((UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < (DateTime.Now.AddDays(2))) && (UtilityMethods.ParseDateInCorrectFormat(appointment.Date) >= DateTime.Now))).ToList();
        }
        private List<DoctorAppointment> CheckIfAppointmentsAreInFuture(List<DoctorAppointment> allValidAppointments)
        {
            return allValidAppointments.Where(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) > DateTime.Now.AddDays(2)).ToList();
        }
        private DoctorAppointment CheckIfAppointmentsAreInFutureFromToday(DoctorAppointment appointment)
        {
            return (UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < DateTime.Now.AddDays(2)) ? null : appointment;
        }
    }
}