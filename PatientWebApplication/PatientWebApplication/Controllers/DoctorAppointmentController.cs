using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Adapters;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAppointmentController : ControllerBase
    {
        private RegularAppointmentService regularAppointmentService;

        public DoctorAppointmentController()
        {
            this.regularAppointmentService = new RegularAppointmentService(new AppointmentRepository());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(this.regularAppointmentService.GetAppointmentsForPatient(id)));
        }

        [HttpPost("search")]
        public IActionResult SimpleSearchAppointments(AppointmentReportSearchDto dto)
        {
            return Ok(new AppointmentAdapter().ConvertAppointmentListToAppointmentDtoList(this.regularAppointmentService.SimpleSearchAppointments(dto)));
        }
        /// <summary> This method is calling <c>regularAppointmentService</c> to get list of all <c>DoctorAppointment</c>. </summary>
        /// <returns> 200 Ok with list of all patient prescriptions. </returns>
        [HttpGet("patient")]       
        public IActionResult GetAppointmentsForPatient()
        {
            return Ok(this.regularAppointmentService.GetAppointmentsForPatient(2)); 
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

    }
}
