using HealthClinic.CL.DbContextModel;
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
    public class PatientUserController : ControllerBase
    {
        private PatientService PatientService { get; set; }

        public PatientUserController()
        {
            PatientService = new PatientService(new PatientsRepository());
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



    }
}
