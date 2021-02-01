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
            if(ReportService.SendReport(date)) return Ok();
            return BadRequest();
        }
    }
}