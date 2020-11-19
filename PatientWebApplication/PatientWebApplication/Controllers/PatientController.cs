using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
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

        public PatientUserController(MyDbContext context)
        {
            PatientService = new PatientService(context);
        }

        [HttpPost]
        public IActionResult Create(PatientUser patientUser)
        {

            if (PatientService.Create(patientUser) == null)
            {
                return BadRequest();
            }
           
            return Ok();
            

        }



    }
}
