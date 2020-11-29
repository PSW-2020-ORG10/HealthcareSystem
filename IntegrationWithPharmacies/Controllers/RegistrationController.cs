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
using IntegrationWithPharmacies.FileProtocol;
using System.IO;
using Microsoft.Extensions.Logging.Abstractions;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Model.Orders;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationInPharmacyService registrationInPharmacyService { get; set; }
        public RegistrationController(MyDbContext context)
        {
            registrationInPharmacyService = new RegistrationInPharmacyService(context);
        }

        [HttpGet]  
        public IActionResult Get()
        {
           
            return Ok(registrationInPharmacyService.GetAll());
        }

        [HttpPost]      
        public IActionResult Post(RegistrationInPharmacyDto dto)
        {
            if (registrationInPharmacyService.Create(dto) == null) return BadRequest();
            return Ok();
        }


    }
}