using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientWebApplication.Models;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            List<Feedback> result = new List<Feedback>();
            //Program.Feedback.ForEach(product => result.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(Program.Feedback);
        }
    }
}
