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
    [Route("api/[controller]")]
    [ApiController]
    public class PatientUserController : ControllerBase
    {
        private PatientService PatientService { get; set; }
        private IWebHostEnvironment _env;



        public PatientUserController(IWebHostEnvironment env)
        {
            PatientService = new PatientService(new PatientsRepository(), new EmailVerificationService());
            _env = env;
        }

        [HttpPost]
        public IActionResult Create(PatientDto patientDto)
        {
            if (PatientService.Create(patientDto) == null)
            {
                return BadRequest();
            }
           
            return Ok();
            

        }

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

    }
}
