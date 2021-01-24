using Microsoft.AspNetCore.Mvc;
using PharmacyRegistrationApi.DbContextModel;
using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Service;
using System;

namespace PharmacyRegistrationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private RegistrationInPharmacyService RegistrationInPharmacyService { get; set; }
        public RegistrationController(MyDbContext context)
        {
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
        }

        [HttpGet]  
        public IActionResult Get()
        {
            return Ok(RegistrationInPharmacyService.GetAll());
        }

        [HttpPost]      
        public IActionResult Post(RegistrationInPharmacyDto dto)
        {
            if (RegistrationInPharmacyService.Create(dto) == null) return BadRequest();
            return Ok();
        }
    }
}