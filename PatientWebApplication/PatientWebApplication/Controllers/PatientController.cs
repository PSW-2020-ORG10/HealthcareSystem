using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
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

        public PatientUserController()
        {
            PatientService = new PatientService(new PatientsRepository(), new EmailVerificationService());
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
            string pathToReturn = PatientService.ImageToSave(file);
            if (pathToReturn == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(pathToReturn);
        

        }

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

    }
}
