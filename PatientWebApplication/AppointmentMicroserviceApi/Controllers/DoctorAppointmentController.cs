using System;
using System.Threading.Tasks;
using AppointmentMicroserviceApi.Adapters;
using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Service;
using EventStore.Dtos;
using EventStore.EventDBContext;
using EventStore.Events;
using EventStore.Repository;
using EventStore.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DoctorAppointment = AppointmentMicroserviceApi.Patient.DoctorAppointment;
using MyDbContext = AppointmentMicroserviceApi.DbContextModel.MyDbContext;

namespace AppointmentMicroserviceApi.Controllers
{
    /// <summary>Class <c>OperationController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        /// <value>Property <c>RegularAppointmentService</c> represents the service used for handling business logic.</value>
        private RegularAppointmentService regularAppointmentService;
        private AppointmentSchedulingEventService appointmentSchedulingEventService;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public DoctorAppointmentController(MyDbContext dbContext, EventDbContext eventDbContext = null)
        {
            regularAppointmentService = new RegularAppointmentService(dbContext);
            appointmentSchedulingEventService = eventDbContext != null ? new AppointmentSchedulingEventService(new AppointmentSchedulingEventRepository(eventDbContext)) : null;
        }

        [HttpGet("getAll")]
        [Authorize(Roles = "patient")]
        public IActionResult GetAll()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAll()));
        }

        [HttpGet("getAllDto")]
        [AllowAnonymous]
        public IActionResult GetAllDto()
        {
            return Ok(CancelAppointmentAdapter.ConvertAppointmentListToAppointmentDtoList(regularAppointmentService.GetAll()));
        }

        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all appointments of one patient. </summary>
        /// <returns> 200 Ok with list of patient's appointments. </returns>
        [HttpGet("{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult Get(int id)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(regularAppointmentService.GetAppointmentsForPatient(id)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that is happening in two days. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in two days. </returns>
        [HttpGet("patientInTwoDays/{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetAppointmentsForPatientInTwoDays(int id)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatientInTwoDays(id)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that are going to happen. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in future. </returns>
        [HttpGet("patientInFuture/{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetAppointmentsForPatientInFuture(int id)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatientInFuture(id)));
        }

        /// <summary> This method provides <paramref name="appointmentId"/> and sends it to <c>RegularAppointmentService</c> there appointment.IsCanceled will be set to true. </summary>
        /// <param name="appointmentId"> is <c>DoctorAppointment</c> that needs to be canceled.
        /// </param>
        /// <returns>200 Ok with canceled appointment.</returns>
        [HttpPut("{appointmentId}")]
        [Authorize(Roles = "patient")]
        public IActionResult CancelAppointment(int appointmentId)
        {
            DoctorAppointment appointment = regularAppointmentService.CancelAppointment(appointmentId);
            if (appointment == null) return BadRequest();
            return Ok(ViewAppointmentAdapter.AppointmentToViewAppointmenDto(appointment));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all recommended appointments. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains doctor id, start date, end date and priority and will be used for getting recommended appointments. 
        /// </param>
        /// <returns> 200 Ok with list of all recommended appointments. </returns>
        [HttpPost("recommend")]
        [Authorize(Roles = "patient")]
        public IActionResult RecommendAppointmentSchedule(RecommendedAppointmentDto dto)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetRecommendedAppointmentAsync(dto)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get all available appointments based on dto object. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains date, doctor id and patient id and will be used for getting available appointments. 
        /// </param>
        /// <returns> 200 Ok with list of all available appointments. </returns>
        [HttpPost("availableappointments")]
        [Authorize(Roles = "patient")]
        public async Task<IActionResult> GetAvailableAppointmentsAsync(AvailableAppointmentsSearchDto dto)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(await regularAppointmentService.GetAllAvailableAppointmentsForDateAsync(dto.Date, dto.DoctorId, dto.PatientId)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to schedule regular appointment. </summary>
        /// <param name="appointment"> Appointment that is going to be scheduled.
        /// </param>
        /// <returns> if <paramref name="appointment"/> is invalid send 400 Bad Request; otherwise 200 Ok with scheduled regular appointment </returns>
        [HttpPost]
        [Authorize(Roles = "patient")]
        public IActionResult Post(DoctorAppointment appointment)
        {
            DoctorAppointment doctorAppointment = regularAppointmentService.CreateRegular(appointment);
            if (doctorAppointment == null)
            {
                return BadRequest();
            }
            return Ok(ViewAppointmentAdapter.AppointmentToViewAppointmenDto(doctorAppointment));
        }

        [HttpGet("appointmentsForDoctor/{doctorId}")]
        [Authorize(Roles = "patient")]
        public IActionResult DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForDoctor(doctorId)));
        }

        [HttpGet("appointmentsForPatient/{patientId}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetAppointmentsForPatient(int patientId)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }

        [HttpGet("appointmentsForPatientDto/{patientId}")]
        [AllowAnonymous]
        public IActionResult GetAppointmentsForPatientDto(int patientId)
        {
            return Ok(SearchAppointmentAdapter.AppointmentListToSearchAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }

        [HttpGet("appointmentsForPatientDtoSimple/{patientId}")]
        [AllowAnonymous]
        public IActionResult GetAppointmentsForPatientDtoSimple(int patientId)
        {
            return Ok( new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }

        private void CreateAppointmentSchedulingEvent(AppointmentSchedulingEventDto dto)
        {
            if (appointmentSchedulingEventService != null)
            {
                if (dto.EndPoint.Equals("start"))
                {
                    appointmentSchedulingEventService.Create(new AppointmentSchedulingEvent(dto.PatientId, dto.Step, dto.Action, dto.EndPoint, appointmentSchedulingEventService.FindNextAttempt()));
                } else
                {
                    appointmentSchedulingEventService.Create(new AppointmentSchedulingEvent(dto.PatientId, dto.Step, dto.Action, dto.EndPoint, appointmentSchedulingEventService.FindNextAttempt() - 1));
                }
            }
        }

        [HttpPost("storeEvent")]
        [Authorize(Roles = "patient")]
        public IActionResult StoreAppointmentSchedulingEvent(AppointmentSchedulingEventDto dto)
        {
            CreateAppointmentSchedulingEvent(dto);
            return Ok();
        }

        [HttpGet("getStatisticsMinSteps")]
        [Authorize(Roles = "admin")]
        public IActionResult GetStatisticsEventsMinSteps()
        {  
            return Ok(CountStepsEventWithPatientAdapter.CountStepsEventDtoToCountStepsEventWithPatientDto(appointmentSchedulingEventService.GetStatisticsMinSteps()));
        }

        [HttpGet("getStatisticsMaxSteps")]
        [Authorize(Roles = "admin")]
        public IActionResult GetStatisticsEventsMaxSteps()
        {
            return Ok(CountStepsEventWithPatientAdapter.CountStepsEventDtoToCountStepsEventWithPatientDto(appointmentSchedulingEventService.GetStatisticsMaxSteps()));
        }

        [HttpGet("getStatisticsOldPersonAverage")]
        [Authorize(Roles = "admin")]
        public IActionResult GetStatisticsEventsOldPerson()
        {
            return Ok(CountStepsEventWithPatientAdapter.CountStepsEventDtoToCountStepsEventWithPatientDto(appointmentSchedulingEventService.GetStatisticsMaxSteps()));
        }

        [HttpGet("getStatisticsYoungPersonAverage")]
        [Authorize(Roles = "admin")]
        public IActionResult GetStatisticsEventsYoungPerson()
        {
            return Ok(CountStepsEventWithPatientAdapter.CountStepsEventDtoToCountStepsEventWithPatientDto(appointmentSchedulingEventService.GetStatisticsMaxSteps()));
        }

        [HttpGet("getSuccessfulAttemptsRatio")]
        [Authorize(Roles = "admin")]
        public IActionResult GetSuccessfulAttemptsRatio()
        {
            return Ok(appointmentSchedulingEventService.GetSuccessfulAttemptsRatio());
        }

        [HttpGet("getMostCanceledStep")]
        [Authorize(Roles = "admin")]
        public IActionResult GetMostCanceledStep()
        {
            return Ok(appointmentSchedulingEventService.GetMostCanceledStep());
        }

    }
}
