using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserMicroserviceApi.Adapters;
using UserMicroserviceApi.DbContextModel;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;

namespace UserMicroserviceApi.Controllers
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

        public PatientUserController(IWebHostEnvironment env, MyDbContext dbContext)
        {
            PatientService = new PatientService(new PatientsRepository(dbContext), new EmailVerificationService(dbContext));
            _env = env;
        }

        /// <summary> This method determines if <c>PatientDto</c> provided <paramref name="dto"/> is valid for creating by calling <c>PatientValidator</c>
        /// automatically and sends it to <c>PatientService</c>. </summary>  
        /// <returns> if fields from <paramref name="dto"/> are not valid 400 Bad Request also if created feedback is not null 200 Ok else 404 Bad Request.</returns>
        [HttpPost]
        [AllowAnonymous]
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
        [AllowAnonymous]
        public IActionResult SaveImg([FromForm] FileModel file)
        {
            string fileName = PatientService.ImageToSave(_env.WebRootPath, file);
            if (fileName == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(fileName);


        }

        [HttpGet("getimage/{fileName}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetImage(string fileName)
        {
            if (fileName == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(File(PatientService.GetImage(_env.WebRootPath, fileName), "image/jpeg"));
        }

        /// <summary> This method is calling <c>PatientService</c> to validate patients account. </summary>
        /// <param name="id"><c>id</c> is id of patient who's account needs to be validated. 
        /// </param>
        /// <returns> If <paramref name="id"/> is not valid returns 400 Bad Request; if business logic is not valid, returns 404 Not Found, if patients account is successfully validated, it redirects to Homepage</returns>
        [HttpGet("{id}")]       // GET /api/patientuser/{id}
        [AllowAnonymous]
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
            return Redirect("http://localhost:3000");

        }

        /// <summary> This method is calling <c>PatientService</c> to get one <c>PatientUser</c>. </summary>
        /// <param name="id"><c>id</c> is id of patient that needs to be found. 
        /// </param>
        /// <returns> If <paramref name="id"/>and patient is not valid returns 400 Bad Request; if patient is successfully found, returns 200 OK with found patient.</returns>
        [HttpGet("getOne/{id}")]
        public IActionResult GetOne(int id)
        {
            PatientUser patient = PatientService.GetOne(id);
            if (id < 0 && patient == null)
            {
                return BadRequest();
            }
            return Ok(patient);
        }

        [HttpGet("getOneEventDto/{id}")]
        [AllowAnonymous]
        public IActionResult GetOneEventDto(int id)
        {
            PatientUser patient = PatientService.GetOne(id);
            if (id < 0 && patient == null)
            {
                return BadRequest();
            }
            return Ok(MicroservicePatientUserAdapter.PatientToMicroservicePatinentUserDto(patient));
        }

        [HttpGet("find/{id}")]
        [Authorize(Roles = "patient")]
        public IActionResult GetOnePatient(int id)
        {
            PatientUser patient = PatientService.GetOne(id);
            if (id < 0 && patient == null)
            {
                return BadRequest();
            }
            return Ok(patient);
        }

        [HttpGet("findDto/{id}")]
        public IActionResult GetOnePatientDto(int id)
        {
            PatientUser patient = PatientService.GetOne(id);
            if (id < 0 && patient == null)
            {
                return BadRequest();
            }
            return Ok(MicroservicePatientAdapter.PatientToMicroservicePatinentDto(patient));
        }

        /// <summary> This method is calling <c>PatientService</c> to get list of all patients. </summary>
        /// <returns> 200 Ok with list of all patients. </returns>
        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Ok(PatientService.GetAll());
        }

        /// <summary> This method is calling <c>PatientService</c> to get malicious <c>PatientUser</c>. </summary>
        /// <returns> 200 Ok with list of all malicious patients.</returns>
        [HttpGet("malicious")]
        [Authorize(Roles = "admin")]
        public IActionResult GetMalicious()
        {
            return Ok(PatientService.GetMaliciousPatients());
        }

        /// <summary> This method provides <paramref name="patientId"/> and sends it to <c>PatientService</c> there patient.IsBlocked will be set to true. </summary>
        /// <param name="patientId"> is <c>PatientUser</c> that needs to be blocked.
        /// </param>
        /// <returns>200 Ok with blocked patient.</returns>
        [HttpPut("{patientId}")]
        [Authorize(Roles = "admin")]
        public IActionResult BlockPatient(int patientId)
        {
            PatientUser patient = PatientService.BlockPatient(patientId);
            if (patient == null) return BadRequest();
            return Ok(patient);
        }

        [HttpGet("all")]       // GET /api/patient/all
        public IActionResult GetWithoutAuthorization()
        {
            return Ok(PatientService.GetAll());
        }
    }
}
