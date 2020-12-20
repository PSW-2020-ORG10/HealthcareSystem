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
    /// <summary>Class <c>SurveyController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        /// <value>Property <c>SurveyService</c> represents the service used for handling business logic.</value>
        private SurveyService SurveyService { get; set; }

        /// <value>Property <c>RegularAppointmentService</c> represents the service used for handling business logic.</value>
        private RegularAppointmentService regularAppointmentService { get; set; }

        /// <summary>This constructor injects the SurveyController with matching SurveyService and RegularAppointmentService.</summary>
        public SurveyController()
        {
            SurveyService = new SurveyService(new SurveyRepository());
            regularAppointmentService = new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository()));
        }

        /// <summary> This method determines if <c>SurveyDto</c> provided <paramref name="surveyDto"/> is valid for creating by calling <c>SurveyValidator</c>
        /// automatically and sends it to <c>SurveyService</c>. </summary>  
        /// <returns> if fields from <paramref name="surveyDto"/> are not valid 400 Bad Request also if created feedback is not null 200 Ok else 404 Bad Request.</returns>
        [HttpPost]
        public IActionResult Create(SurveyDto surveyDto)
        {
            if (SurveyService.Create(surveyDto) == null)
            {
                return BadRequest();
            }
            return Ok();
        }


        /// <summary> This method is calling <c>RegularAppointmentService</c> to get List of <c>DoctorAppointment</c> that are valid for survey. </summary>
        /// <returns> If List of <c>DoctorAppointment</c> is successfully found, returns 200 OK with list of good DoctorAppointments, otherwise it returns 200 OK with empty list.</returns>
        [HttpGet]      
        public IActionResult Get()
        {                  
            return Ok(regularAppointmentService.FindAllValidAppointmentsWithoutSurvey(regularAppointmentService.GetAppointmentsForPatient(2), SurveyService.GetAllSurveysForPatientId(2)));
        }

        [HttpGet("getWithSurveys")]
        public IActionResult GetWithSurveys()
        {
            return Ok(regularAppointmentService.FindAllValidAppointmentsWithSurvey(regularAppointmentService.GetAppointmentsForPatient(2), SurveyService.GetAllSurveysForPatientId(2)));
        }
        /// <summary> This method is calling <c>FeedbackService</c> to get rates for doctors, medical staff and hospital in general. </summary>
        /// <returns> If returned <c>SurveyAverageDto</c> is null returns 400 Bad Request; If returned <c>SurveyAverageDto</c> is not null, returns 200 OK with found dto</returns>
        [HttpGet("getRates")]
        public IActionResult GetRates()
        {
            SurveyAverageDto surveyAverage = SurveyService.GetAllAverageRates();
            if (surveyAverage == null)
            {
                return BadRequest();
            }
            return Ok(surveyAverage);
        }

        /// <summary> This method is calling <c>FeedbackService</c> to get all rates for every doctor that was found in surveys. </summary>
        /// <returns> If returned list of <c>SurveyDoctorAverageDto</c> is null returns 400 Bad Request; If returned  list of <c>SurveyDoctorAverageDto</c> is not null, returns 200 OK with list of found dto</returns>
        [HttpGet("getDoctorRates")]
        public IActionResult GetDoctorRates()
        {
            List<SurveyDoctorAverageDto> surveyDoctorAverage = SurveyService.GetAllDoctorAverageRates();
            if (surveyDoctorAverage == null)
            {
                return BadRequest();
            }
            return Ok(surveyDoctorAverage);
        }
    }
}
