using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Controllers
{
    /// <summary>Class <c>PatientUserController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PatientUserController : ControllerBase
    {
        /// <value>Property <c>PatientService</c> represents the service used for handling business logic.</value>
        private PatientService PatientService { get; set; }
        private IWebHostEnvironment _env;
        private RegularAppointmentService regularAppointmentService { get; set; }
        /// <summary>This constructor injects the PatientUserController with matching PatientService.</summary>
        public PatientUserController(IWebHostEnvironment env)
        {
            PatientService = new PatientService(new PatientsRepository(), new EmailVerificationService(), new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository())));
            _env = env;
        }
        /// <summary> This method determines if <c>PatientDto</c> provided <paramref name="dto"/> is valid for creating by calling <c>PatientValidator</c>
        /// automatically and sends it to <c>PatientService</c>. </summary>  
        /// <returns> if fields from <paramref name="dto"/> are not valid 400 Bad Request also if created feedback is not null 200 Ok else 404 Bad Request.</returns>
        [HttpPost]
        public IActionResult Create(PatientDto patientDto)
        {
            if (PatientService.Create(patientDto) == null)
            {
                return BadRequest();
            }

            return Ok();


        }

        /// <summary> This method calls <c>FeedbackService</c> to save image. </summary>
        /// <param name="file"><c>id</c> is File model that needs to be saved. 
        /// </param>
        /// <returns> If <paramref name="file"/> is not valid returns 400 Bad Request; if business logic is not valid, returns 404 Not Found, if path is successfully returned, returns 200 OK with path</returns>
        [HttpPost("image")]
        public IActionResult SaveImg([FromForm] FileModel file)
        {
            string path = _env.WebRootPath;
            string fileName = PatientService.ImageToSave(path, file);
            if (fileName == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(fileName);


        }

        /// <summary> This method is calling <c>PatientService</c> to validate patients account. </summary>
        /// <param name="id"><c>id</c> is id of patient who's account needs to be validated. 
        /// </param>
        /// <returns> If <paramref name="id"/> is not valid returns 400 Bad Request; if business logic is not valid, returns 404 Not Found, if patients account is successfully validated, it redirects to Homepage</returns>
        [HttpGet("{id}")]       // GET /api/patientuser/{id}
        public IActionResult Validate(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            // checking if feedback exists in database
            PatientUser result = PatientService.Validate(id);
            if (result == null)
            {
                return NotFound();
            }
            return Redirect("http://localhost:60198");

        }

        /// <summary> This method is calling <c>PatientService</c> to get one <c>PatientUser</c>. </summary>
        /// <param name="id"><c>id</c> is id of patient that needs to be found. 
        /// </param>
        /// <returns> If <paramref name="id"/>and patient is not valid returns 400 Bad Request; if patient is successfully found, returns 200 OK with found patient.</returns>
        [HttpGet("getOne")]
        public IActionResult GetOne(int id)
        {
            PatientUser patient = PatientService.GetOne(3);
            if (id < 0 && patient == null)
            {
                return BadRequest();
            }
            return Ok(patient);
        }

        /// <summary> This method is calling <c>PatientService</c> to get list of all patients. </summary>
        /// <returns> 200 Ok with list of all patients. </returns>
        [HttpGet]       
        public IActionResult Get()
        {
            //List<PatientUser> result = PatientService.GetAll();
            return Ok(PatientService.GetAll());
        }

        /// <summary> This method is calling <c>PatientService</c> to get malicious <c>PatientUser</c>. </summary>
        /// <returns> 200 Ok with list of all malicious patients.</returns>
        [HttpGet("malicious")]    
        public IActionResult GetMalicious()
        {
           // List<PatientUser> result = PatientService.GetMaliciousPatients();
            return Ok(PatientService.GetMaliciousPatients()); 
        }

        /// <summary> This method provides <paramref name="patientId"/> and sends it to <c>PatientService</c> there patient.IsBlocked will be set to true. </summary>
        /// <param name="patientId"> is <c>PatientUser</c> that needs to be blocked.
        /// </param>
        /// <returns>200 Ok with blocked patient.</returns>
        [HttpPut("{patientId}")]
        public IActionResult BlockPatient(int patientId)
        {
            PatientUser patient = this.PatientService.BlockPatient(patientId);
            if (patient == null) return BadRequest();
            return Ok(patient);
        }
    }
}
