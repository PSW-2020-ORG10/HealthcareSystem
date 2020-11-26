using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private SurveyService SurveyService { get; set; }
        private RegularAppointmentService regularAppointmentService { get; set; }
        private AppointmentSurveyRepository AppointmentSurveyRepository { get; set; }
        public SurveyController()
        {
            SurveyService = new SurveyService(new SurveyRepository());
            AppointmentSurveyRepository = new AppointmentSurveyRepository();
            regularAppointmentService = new RegularAppointmentService(new AppointmentRepository());
        }

        [HttpPost]
        public IActionResult Create(SurveyDto surveyDto)
        {
            if (SurveyService.Create(surveyDto) == null)
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]      
        public IActionResult Get()
        {       
            List<DoctorAppointment> allValidAppointments = regularAppointmentService.GetAppointmentsForPatient(1);          
            allValidAppointments = SurveyService.FindAllValidAppointments(allValidAppointments);
            return Ok(allValidAppointments);
        }

       
    }
}
