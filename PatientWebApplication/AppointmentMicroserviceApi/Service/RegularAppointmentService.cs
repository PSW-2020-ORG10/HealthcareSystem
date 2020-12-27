/***********************************************************************
 * Module:  RegularAppointmentService.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Service.RegularAppointmentService
 ***********************************************************************/
using Castle.Core.Internal;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Employee;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using HealthClinic.CL.Utility;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using System.Threading.Tasks;
using HealthClinic.CL.Service;
using AppointmentMicroserviceApi.Repository;

namespace AppointmentMicroserviceApi.Service
{
    public class RegularAppointmentService : BingPath, IStrategyAppointment
    {
        private IAppointmentRepository _appointmentRepository;
        private OperationService operationService;

        public RegularAppointmentService(IAppointmentRepository appointmentRepository, OperationService operationService)
        {
            _appointmentRepository = appointmentRepository;
            this.operationService = operationService;
        }

        public RegularAppointmentService(MyDbContext context)
        {
            _appointmentRepository = new AppointmentRepository(context);
            operationService = new OperationService(new OperationRepository(context));
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
            if (!GetAllAvailableAppointmentsForDateAsync(appointment.Date, appointment.DoctorUserId, appointment.PatientUserId).Result.Contains(appointment)) return;
            _appointmentRepository.New(appointment);
        }


        /// <summary> This method is calling <c>AppointmentRepository</c> to create new appointment. </summary>
        /// <param name="appointment"><c>appointment</c> is appointment we want to create.</param>
        /// <returns> Created appointment. </returns>
        public DoctorAppointment CreateRecommended(DoctorAppointment appointment)
        {
            return _appointmentRepository.New(appointment);
        }

        public DoctorAppointment CreateRegular(DoctorAppointment appointment)
        {
            var appointments = GetAllAvailableAppointmentsForDateAsync(appointment.Date, appointment.DoctorUserId, appointment.PatientUserId).Result;
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
        public List<DoctorAppointment> GetRecommendedAppointmentAsync(RecommendedAppointmentDto dto)
        {
            DoctorUser doctor = HttpRequests.GetDoctorByIdAsync(dto.DoctorId).Result;
            DateTime startDate = UtilityMethods.ParseDateInCorrectFormat(dto.Start);
            DateTime endDate = UtilityMethods.ParseDateInCorrectFormat(dto.End);
            PatientUser patient = HttpRequests.GetOnePatient(2).Result; //still no login, change after login, id set to 1
            List<DoctorAppointment> recomendedAppointments = GetAllAvailableAppointmentsForRecommendedDatesAsync(dto.DoctorId, startDate, endDate, patient.id).Result;

            if (!recomendedAppointments.Any())
            {
                if (dto.Priority.Equals("doctor"))
                {
                    endDate = (endDate - startDate).TotalDays > 20 ? endDate.AddDays(10) : (endDate - startDate).TotalDays > 10 ? endDate.AddDays(5) : endDate.AddDays(3);

                    recomendedAppointments = GetAllAvailableAppointmentsForRecommendedDatesAsync(dto.DoctorId, startDate, endDate, patient.id).Result;
                }
                else
                {
                    recomendedAppointments = RecommenedAnAppointmentDatePriorityAsync(startDate, endDate, patient, doctor.speciality).Result;
                }
            }

            return recomendedAppointments;
        }

        public DoctorAppointment RecommendAnAppointment(DoctorUser doctor, DateTime startDate, DateTime endDate, PatientUser patient)
        {
            TimeSpan time1 = TimeSpan.FromMinutes(15);

            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                if (GetAvailableTermAsync(doctor, date, time1, patient).Result != null) return GetAvailableTermAsync(doctor, date, time1, patient).Result;
            }
            return null;
        }

        /// <summary> This method is getting List of <c>DoctorAppointment</c> when doctor and patient are available </summary>
        /// <param name="doctorId"><c>DoctorUser</c> id of doctor who will execute appointment</param>
        /// <param name="startDate">From which date we want to get recommended appointment</param>
        /// <param name="endDate">To which date we want to get recommended appointment</param>
        /// <param name="patientId"><c>PatientUser</c> id of patient that is scheduling appointment</param>
        /// <returns> List of recommended appointments</returns>
        public async Task<List<DoctorAppointment>> GetAllAvailableAppointmentsForRecommendedDatesAsync(int doctorId, DateTime startDate, DateTime endDate, int patientId)
        {
            List<DoctorAppointment> availableAppointments = new List<DoctorAppointment>();
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                Shift doctorShift = await HttpRequests.GetShiftForDoctorForSpecificDay(new DoctorShiftSearchDto(doctorId, MakeStringFromDate(date)));
                if (doctorShift == null)
                {
                    continue;
                }

                TimeSpan time = TimeSpan.Parse(doctorShift.startTime);

                availableAppointments = await GetAvailableForFreeTimeAsync(time, availableAppointments, doctorShift, doctorId, date, patientId);
            }

            return availableAppointments;
        }

        private async Task<List<DoctorAppointment>> GetAvailableForFreeTimeAsync(TimeSpan time, List<DoctorAppointment> availableAppointments, Shift doctorShift, int doctorId, DateTime date, int patientId)
        {
            while (time != TimeSpan.Parse(doctorShift.endTime) && availableAppointments.Count < 5)
            {
                if (time < DateTime.Now.TimeOfDay && UtilityMethods.CheckIfDateIsToday(date))
                {
                    time = time.Add(TimeSpan.FromMinutes(15));
                    continue;
                }
                availableAppointments = await GetListAvailableAppointmentsAsync(availableAppointments, doctorId, time, date, patientId);
                time = time.Add(TimeSpan.FromMinutes(15));
            }
            return availableAppointments;
        }

        private async Task<List<DoctorAppointment>> GetListAvailableAppointmentsAsync(List<DoctorAppointment> availableAppointments, int doctorId, TimeSpan time, DateTime date, int patientId)
        {
            List<TimeSpan> startTimesAppointments = GetAllStartTimes(CreateAppointmentSetForDate(date, doctorId, patientId).ToList());
            List<Operation> operations = operationService.CreateOperationtSetForDate(date, doctorId, patientId).ToList();
            if (!startTimesAppointments.Contains(time) && !operationService.IsOperationInTimePeriod(time, operations) || availableAppointments.Count >= 5)
            {
                availableAppointments.Add(new DoctorAppointment(0, time, MakeStringFromDate(date), await HttpRequests.GetOnePatient(patientId), await HttpRequests.GetDoctorByIdAsync(doctorId), new List<Referral>(), HttpRequests.GetDoctorByIdAsync(doctorId).Result.ordination));
            }

            return availableAppointments;
        }

        /// <summary> This method is getting all appointments of one doctor on given date. </summary>
        /// <returns> list of all doctor's appointments on specific date. </returns>
        private List<DoctorAppointment> GetAllAppointmentsByDateAndDoctor(DateTime date, int doctorId)
        {
            return GetAppointmentsForDoctor(doctorId).Where(appointment => date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && !appointment.IsCanceled).ToList();
        }

        /// <summary> This method is getting all appointments of one patient on given date. </summary>
        /// <returns> list of all patients's appointments on specific date. </returns>
        private List<DoctorAppointment> GetAllAppointmentsByDateAndPatient(DateTime date, int patientId)
        {
            return GetAppointmentsForPatient(patientId).Where(appointment => date == UtilityMethods.ParseDateInCorrectFormat(appointment.Date) && !appointment.IsCanceled).ToList();
        }

        private async Task<DoctorAppointment> GetAvailableTermAsync(DoctorUser doctor, DateTime date, TimeSpan time1, PatientUser patient)
        {
            Shift doctorShift = await HttpRequests.GetShiftForDoctorForSpecificDay(new DoctorShiftSearchDto(doctor.id, MakeStringFromDate(date)));

            if (doctorShift != null && doctorShift.startTime != null && doctorShift.endTime != null)
                return GetNewDoctorAppointment(doctor, date, time1, patient, doctorShift);

            return null;
        }

        /// <summary> This method is getting all available appointments of one doctor and one patient on given date. </summary>
        /// <param name="dateString">Date for which this method get's all available appointments</param>
        /// <param name="doctorId">Id of doctor for whom this method get's all available appointments</param>
        /// <param name="patientId">Id of patient for whom this method get's all available appointments</param>
        /// <returns> list of all available appointments on specific date for given doctor and patient. </returns>
        public async Task<List<DoctorAppointment>> GetAllAvailableAppointmentsForDateAsync(string dateString, int doctorId, int patientId)
        {
            Shift doctorShift = await HttpRequests.GetShiftForDoctorForSpecificDay(new DoctorShiftSearchDto(doctorId, dateString));
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
                if (time < DateTime.Now.TimeOfDay && UtilityMethods.CheckIfDateIsToday(dateString))
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
                availableAppointments.Add(new DoctorAppointment(0, time, dateString, patientId, doctorId, new List<Referral>(), HttpRequests.GetDoctorByIdAsync(doctorId).Result.ordination));
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
            List<TimeSpan> startTimes = new List<TimeSpan>();
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
                if (!IsTermNotAvailableAsync(doctor, time, MakeStringFromDate(date), patient).Result)
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
            string[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[0]);
        }

        private int GetMinutesStart(Shift doctorShift)
        {
            string[] partsBegin = doctorShift.startTime.Split(':');
            return int.Parse(partsBegin[1]);
        }
        private int GetHourEnd(Shift doctorShift)
        {
            string[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[0]);
        }

        private int GetMinutesEnd(Shift doctorShift)
        {
            string[] partsEnd = doctorShift.endTime.Split(':');
            return int.Parse(partsEnd[1]);
        }

        /// <summary> This method is getting List of <c>DoctorAppointment</c> when priority is date </summary>
        /// <param name="startDate">From which date we want to get recommended appointment</param>
        /// <param name="endDate">To which date we want to get recommended appointment</param>
        /// <param name="patient"><c>PatientUser</c> who is scheduling appointment</param>
        /// <param name="speciality">Speciality of doctor which patient wanted first to execute appointment</param>
        /// <returns>List of <c>DoctorAppointment</c></returns>
        public async Task<List<DoctorAppointment>> RecommenedAnAppointmentDatePriorityAsync(DateTime startDate, DateTime endDate, PatientUser patient, string speciality)
        {
            List<DoctorUser> doctorsList = await HttpRequests.GetAllAsync();
            List<DoctorAppointment> appointments = new List<DoctorAppointment>();

            foreach (DoctorUser doctor in doctorsList)
            {
                if (doctor.speciality.Equals(speciality) && GetAllAvailableAppointmentsForRecommendedDatesAsync(doctor.id, startDate, endDate, patient.id).Result.Any())
                    return GetAllAvailableAppointmentsForRecommendedDatesAsync(doctor.id, startDate, endDate, patient.id).Result;
            }
            return appointments;
        }

        public async Task<bool> IsTermNotAvailableAsync(DoctorUser doctor, TimeSpan time, string dateToString, PatientUser patient)
        {
            bool hasAppointmentDoctor = await HttpRequests.DoesDoctorHaveAnAppointmentAtSpecificTime(doctor.id, time, dateToString);
            bool hasOperationDoctor = await HttpRequests.DoesDoctorHaveAnOperationAtSpecificTime(doctor.id, time, dateToString);

            if (hasAppointmentDoctor == true || hasOperationDoctor == true) return true;

            return false;
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
            return appointment == null ? null : _appointmentRepository.CancelAppointment(appointment);
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
            return allValidAppointments.Where(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < DateTime.Now.AddDays(2) && UtilityMethods.ParseDateInCorrectFormat(appointment.Date) >= DateTime.Now).ToList();
        }
        private List<DoctorAppointment> CheckIfAppointmentsAreInFuture(List<DoctorAppointment> allValidAppointments)
        {
            return allValidAppointments.Where(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) > DateTime.Now.AddDays(2)).ToList();
        }
        private DoctorAppointment CheckIfAppointmentsAreInFutureFromToday(DoctorAppointment appointment)
        {
            return UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < DateTime.Now.AddDays(2) ? null : appointment;
        }
    }
}