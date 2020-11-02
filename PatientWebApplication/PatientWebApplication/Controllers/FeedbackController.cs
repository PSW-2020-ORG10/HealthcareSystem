using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class_diagram.Model.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientWebApplication.Adapters;
using PatientWebApplication.Dtos;
using PatientWebApplication.Models;
using PatientWebApplication.Services;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        public FeedbackController(MyDbContext context)
        {
            this.dbContext = context;
        }

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            List<Feedback> result = new List<Feedback>();
            dbContext.Feedbacks.ToList().ForEach(feedback => result.Add(feedback));
            
            //Program.Feedback.ForEach(product => result.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(result);
        }

        [HttpPost]      // POST /api/feedback Request body: {"message": "message", "color": "blue", "price": 55.4}
        public IActionResult Create(FeedbackDto dto)
        {
            if (dto.Message.Length <= 0)
            {
                return BadRequest();    // if any of the values is incorrect return bad request
            } else
            {
                FeedbackService.Create(dto);
                return Ok();
            }

        }
    }
}
