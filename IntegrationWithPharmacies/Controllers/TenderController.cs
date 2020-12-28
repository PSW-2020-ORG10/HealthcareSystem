using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using IntegrationWithPharmacies.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenderController : ControllerBase
    {
        private TenderService TenderService { get; }

        public TenderController(MyDbContext context)
        {
            TenderService = new TenderService(context);
        }

        [HttpPost]
        public IActionResult Post(Tender tender)
        {  
            if (TenderService.PublishTender(tender)) return Ok();
            return BadRequest();
        }
    }
}