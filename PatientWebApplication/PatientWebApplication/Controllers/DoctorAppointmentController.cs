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

    }
}
