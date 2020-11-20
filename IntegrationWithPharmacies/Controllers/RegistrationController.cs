using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HealthClinic.CL.Services;
using Class_diagram.Model.Patient;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationInPharmacyService registrationInPharmacyService { get; set; }

        public RegistrationController() { }
        public RegistrationController(MyDbContext context)
        {
            registrationInPharmacyService = new RegistrationInPharmacyService(context);
        }

        [HttpGet]   // GET /api/registration
        public IActionResult Get()
        {
            List<RegistrationInPharmacy> result = registrationInPharmacyService.GetAll();
            return Ok(result);
        }

        [HttpPost]      // POST /api/registration Request body: {"pharmacyId": "Some number", "apiKey": "Some api key"}
        public IActionResult Create(RegistrationInPharmacyDto dto)
        {
            RegistrationInPharmacy registration = registrationInPharmacyService.Create(dto);

            if (registration == null) return BadRequest();

            return Ok();
        }

    }
}