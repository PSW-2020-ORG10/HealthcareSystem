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
        
        public SurveyController()
        {
            SurveyService = new SurveyService(new SurveyRepository());
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
            return Ok(regularAppointmentService.FindAllValidAppointments(regularAppointmentService.GetAppointmentsForPatient(1), SurveyService.GetAllSurveysForPatientId(1)));
        }

        [HttpGet("getRates")]
        public IActionResult GetRates()
        {
            SurveyAverageDto surveyAverage = SurveyService.GetAllAverageRates(SurveyService.GetAll());
            if (surveyAverage == null)
            {
                return BadRequest();
            }
            return Ok(surveyAverage);
        }

        [HttpGet("getDoctorRates")]
        public IActionResult GetDoctorRates()
        {
            List<SurveyDoctorAverageDto> surveyDoctorAverage = SurveyService.GetAllDoctorAverageRates(SurveyService.GetAll());
            if (surveyDoctorAverage == null)
            {
                return BadRequest();
            }
            return Ok(surveyDoctorAverage);
        }
    }
}
