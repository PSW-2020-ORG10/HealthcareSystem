using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenderApi.DbContextModel;
using TenderApi.Model;
using TenderApi.Service;

namespace TenderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private ReportService ReportService { get; }

        public ReportController(MyDbContext context)
        {
            ReportService = new ReportService(context);
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