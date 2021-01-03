using System.Threading.Tasks;
using AppointmentMicroserviceApi.Adapters;
using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Service;
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

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public DoctorAppointmentController(MyDbContext context)
        {
            regularAppointmentService = new RegularAppointmentService(context);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAll()));
        }

        [HttpGet("getAllDto")]
        public IActionResult GetAllDto()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAll()));
        }

        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all appointments of one patient. </summary>
        /// <returns> 200 Ok with list of patient's appointments. </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(regularAppointmentService.GetAppointmentsForPatient(id)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that already happened. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that already happened. </returns>
        [HttpGet("patient")]
        public IActionResult GetAppointmentsForPatient()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatient(2)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that is happening in two days. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in two days. </returns>
        [HttpGet("patientInTwoDays")]
        public IActionResult GetAppointmentsForPatientInTwoDays()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatientInTwoDays(2)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that are going to happen. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in future. </returns>
        [HttpGet("patientInFuture")]
        public IActionResult GetAppointmentsForPatientInFuture()
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatientInFuture(2)));
        }

        /// <summary> This method provides <paramref name="appointmentId"/> and sends it to <c>RegularAppointmentService</c> there appointment.IsCanceled will be set to true. </summary>
        /// <param name="appointmentId"> is <c>DoctorAppointment</c> that needs to be canceled.
        /// </param>
        /// <returns>200 Ok with canceled appointment.</returns>
        [HttpPut("{appointmentId}")]
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
        public IActionResult RecommendAppointmentSchedule(RecommendedAppointmentDto dto)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetRecommendedAppointmentAsync(dto)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get all available appointments based on dto object. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains date, doctor id and patient id and will be used for getting available appointments. 
        /// </param>
        /// <returns> 200 Ok with list of all available appointments. </returns>
        [HttpPost("availableappointments")]
        public async Task<IActionResult> GetAvailableAppointmentsAsync(AvailableAppointmentsSearchDto dto)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(await regularAppointmentService.GetAllAvailableAppointmentsForDateAsync(dto.Date, dto.DoctorId, dto.PatientId)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to schedule regular appointment. </summary>
        /// <param name="appointment"> Appointment that is going to be scheduled.
        /// </param>
        /// <returns> if <paramref name="appointment"/> is invalid send 400 Bad Request; otherwise 200 Ok with scheduled regular appointment </returns>
        [HttpPost]
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
        public IActionResult DoesDoctorHaveAnAppointmentAtSpecificTime(int doctorId)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForDoctor(doctorId)));
        }

        [HttpGet("appointmentsForPatient/{patientId}")]
        public IActionResult GetAppointmentsForPatient(int patientId)
        {
            return Ok(ViewAppointmentAdapter.AppointmentListToViewAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }

        [HttpGet("appointmentsForPatientDto/{patientId}")]
        public IActionResult GetAppointmentsForPatientDto(int patientId)
        {
            return Ok(SearchAppointmentAdapter.AppointmentListToSearchAppointmenDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }

        [HttpGet("appointmentsForPatientDtoSimple/{patientId}")]
        public IActionResult GetAppointmentsForPatientDtoSimple(int patientId)
        {
            return Ok( new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(regularAppointmentService.GetAppointmentsForPatient(patientId)));
        }
    }
}
