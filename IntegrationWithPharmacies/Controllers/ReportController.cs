using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReportService reportService { get; set; }

        public ReportController()
        {
            reportService = new ReportService();
        }

        [HttpGet]   // GET /api/registration
        public IActionResult Get()
        {
            

            return Ok(reportService.createAndSendFile());
        }


    }
}