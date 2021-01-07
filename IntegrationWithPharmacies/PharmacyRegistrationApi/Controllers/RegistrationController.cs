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
            Console.WriteLine("U ovom prvom sam");
            RegistrationInPharmacyService = new RegistrationInPharmacyService(context);
        }

        [HttpGet]  
        public IActionResult Get()
        {
            Console.WriteLine("U get sam");
            return Ok(RegistrationInPharmacyService.GetAll());
        }

        [HttpPost]      
        public IActionResult Post(RegistrationInPharmacyDto dto)
        {
            Console.WriteLine("U post sam");
            if (RegistrationInPharmacyService.Create(dto) == null) return BadRequest();
            return Ok();
        }


    }
}