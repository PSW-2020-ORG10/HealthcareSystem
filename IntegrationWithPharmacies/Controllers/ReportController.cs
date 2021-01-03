
using HealthClinic.CL.DbContextModel;
using IntegrationWithPharmacies.FileProtocol;
using Microsoft.AspNetCore.Mvc;

using System;

namespace IntegrationWithPharmacies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private String Environment { get; set; }
        private ReportService ReportService { get; }

      public ReportController(MyDbContext context)
      {
            ReportService = new ReportService(context);
            Environment = "Local";
      }

        [HttpPost]
        public IActionResult Post(DateOfOrder date)
        {
            if (ReportService.SendReportSftp(date)) return Ok();
            return BadRequest();
        }


        [HttpPost("http")]
        public IActionResult PostHttp(DateOfOrder date)
        {
            if (ReportService.SendReportHttp(date)) return Ok();
            return BadRequest();
        }
    }

}