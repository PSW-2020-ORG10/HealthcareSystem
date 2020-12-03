using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private DoctorService DoctorService { get; set; }

        public DoctorController()
        {
            DoctorService = new DoctorService();
        }

        [HttpGet]       // GET /api/doctor
        public IActionResult Get()
        {
            return Ok(DoctorService.GetAll());
        }
    }
}
