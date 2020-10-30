using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using PatientWebApplication.Models;
using PatientWebApplication.Services;

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
            //Program.Feedback.ForEach(product => re sult.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(Program.Feedback);
        }

        [HttpGet("published")]       // GET /api/feedback/published
        public IActionResult GetPublished()
        {
            List<Feedback> result = FeedbackService.GetPublished();
            
            //Program.Feedback.ForEach(product => product.IsPublished ? result.Add(ProductAdapter.ProductToProductDto(product)) : result);
            return Ok(result);
        }

    }
}
