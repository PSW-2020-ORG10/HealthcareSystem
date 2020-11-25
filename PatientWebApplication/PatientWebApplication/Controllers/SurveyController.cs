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
        private AppointmentSurveyRepository AppointmentSurveyRepository { get; set; }
        public SurveyController()
        {
            SurveyService = new SurveyService(new SurveyRepository());
            AppointmentSurveyRepository = new AppointmentSurveyRepository();
        }

        [HttpPost]
        public IActionResult Create(SurveyDto surveyDto)
        {
            if (SurveyService.Create(surveyDto) == null)
            {
                return BadRequest();
            }
            return Redirect("http://localhost:60198");
        }

        [HttpGet]      
        public IActionResult Get()
        {
            //List<DoctorAppointment> result = null;
            List<DoctorAppointment> allValidAppointments = AppointmentSurveyRepository.GetAll();
            List<Survey> allValidSurveys = SurveyService.GetAllSurveysForPatientId(1);
            //List<DoctorAppointment> allUnvalidAppointments = new List<DoctorAppointment>();
            List<int> allUnvalidAppointments = new List<int>();
            foreach (Survey survey in allValidSurveys) {
                allUnvalidAppointments.Add(survey.appointmentId);
            }
            //allValidAppointments.Except(allUnvalidAppointments);
            allValidAppointments = allValidAppointments.Where(p => !allUnvalidAppointments.Any(p2 => p2 == p.id)).ToList();
            // Console.WriteLine(allValidAppointments);
            return Ok(allValidAppointments);
        }


    }
}
