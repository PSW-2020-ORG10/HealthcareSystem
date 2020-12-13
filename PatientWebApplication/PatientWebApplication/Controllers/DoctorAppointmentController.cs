using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    /// <summary>Class <c>OperationController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        /// <value>Property <c>RegularAppointmentService</c> represents the service used for handling business logic.</value>
        private RegularAppointmentService regularAppointmentService;
        private DoctorService doctorService;

        /// <summary>This constructor initiates the DoctorAppointmentController's appointment service.</summary>
        public DoctorAppointmentController(MyDbContext context)
        {
            this.regularAppointmentService = new RegularAppointmentService(context);
            this.doctorService = new DoctorService(context);
        }

        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all appointments of one patient. </summary>
        /// <returns> 200 Ok with list of patient's appointments. </returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(this.regularAppointmentService.GetAppointmentsForPatient(id)));
        }


        /// <summary> This method is calling <c>RegularAppointmentService</c> to get list of all patient <c>DoctorAppointment</c> that matches search dto. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains <c>DoctorNameAndSurname</c>, <c>Start</c>, <c>End</c>, <c>AppointmentType</c>, <c>PatientId</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered patient appointments. </returns>
        [HttpPost("search")]
        public IActionResult SimpleSearchAppointments(AppointmentReportSearchDto dto)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(this.regularAppointmentService.SimpleSearchAppointments(dto)));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that already happened. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that already happened. </returns>
        [HttpGet("patient")]       
        public IActionResult GetAppointmentsForPatient()
        {
            return Ok(this.regularAppointmentService.GetAppointmentsForPatient(2)); 
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that is happening in two days. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in two days. </returns>
        [HttpGet("patientInTwoDays")]
        public IActionResult GetAppointmentsForPatientInTwoDays()
        {
            return Ok(this.regularAppointmentService.GetAppointmentsForPatientInTwoDays(2));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that are going to happen. </summary>
        /// <returns> 200 Ok with list of all patient's appointments that's going to happen in future. </returns>
        [HttpGet("patientInFuture")]
        public IActionResult GetAppointmentsForPatientInFuture()
        {
            return Ok(this.regularAppointmentService.GetAppointmentsForPatientInFuture(2));
        }

        /// <summary> This method provides <paramref name="appointmentId"/> and sends it to <c>RegularAppointmentService</c> there appointment.IsCanceled will be set to true. </summary>
        /// <param name="appointmentId"> is <c>DoctorAppointment</c> that needs to be canceled.
        /// </param>
        /// <returns>200 Ok with canceled appointment.</returns>
        [HttpPut("{appointmentId}")]
        public IActionResult CancelAppointment(int appointmentId)
        {
            DoctorAppointment appointment = this.regularAppointmentService.CancelAppointment(appointmentId);
            if (appointment == null) return BadRequest();
            return Ok(appointment);
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c> that matches <c>Appointment dto</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>DoctorAppointment</c> that contains <c>Doctor</c>, <c>Date</c>, <c>Room</c> and will be used for filtering appointments. 
        /// </param>
        /// <returns> 200 Ok with list of filtered appointments. </returns>
        [HttpPost("advancedsearch")]
        public IActionResult AdvancedSearchAppointments(AppointmentAdvancedSearchDto dto)
        {
            return Ok(this.regularAppointmentService.AdvancedSearchAppointments(dto));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all recommended appointments. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains doctor id, start date, end date and priority and will be used for getting recommended appointments. 
        /// </param>
        /// <returns> 200 Ok with list of all recommended appointments. </returns>
        [HttpPost("recommend")]
        public IActionResult RecommendAppointmentSchedule(RecommendedAppointmentDto dto)
        {
            return Ok(this.regularAppointmentService.GetRecommendedAppointment(dto));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to schedule recommended appointment. </summary>
        /// <param name="appointment"> Recommended appointment that is going to be scheduled.
        /// </param>
        /// <returns> 200 Ok with recommended appointment. </returns>
        [HttpPost("createRecommended")]
        public IActionResult CreateRecommended(DoctorAppointment appointment)
        {
            return Ok(this.regularAppointmentService.CreateRecommended(appointment));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to get all available appointments based on dto object. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object that contains date, doctor id and patient id and will be used for getting available appointments. 
        /// </param>
        /// <returns> 200 Ok with list of all available appointments. </returns>
        [HttpPost("availableappointments")]
        public IActionResult GetAvailableAppointments(AvailableAppointmentsSearchDto dto)
        {
            return Ok(this.regularAppointmentService.GetAllAvailableAppointmentsForDate(dto.Date, dto.DoctorId, dto.PatientId));
        }

        /// <summary> This method is calling <c>regularAppointmentService</c> to schedule regular appointment. </summary>
        /// <param name="appointment"> Appointment that is going to be scheduled.
        /// </param>
        /// <returns> if <paramref name="appointment"/> is invalid send 400 Bad Request; otherwise 200 Ok with scheduled regular appointment </returns>
        [HttpPost]
        public IActionResult Post(DoctorAppointment appointment)
        {
            DoctorAppointment doctorAppointment = this.regularAppointmentService.CreateRegular(appointment);
            if(doctorAppointment == null)
            {
                return BadRequest();
            }
            return Ok(doctorAppointment);
        }
    }
}
