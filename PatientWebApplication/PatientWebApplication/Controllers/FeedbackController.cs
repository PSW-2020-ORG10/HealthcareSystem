﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Class_diagram.Model.Patient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientWebApplication.Models;
using PatientWebApplication.Services;

namespace PatientWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        private FeedbackService feedbackService;
        public FeedbackController(MyDbContext context)
        {
            this.dbContext = context;
            feedbackService = new FeedbackService(context);
        }

        [HttpGet]       // GET /api/feedback
        public IActionResult Get()
        {
            List<Feedback> result = new List<Feedback>();
            dbContext.Feedbacks.ToList().ForEach(feedback => result.Add(feedback));
            
            //Program.Feedback.ForEach(product => result.Add(ProductAdapter.ProductToProductDto(product)));
            return Ok(result);
        }


        [HttpGet("published")]       // GET /api/feedback
        public IActionResult GetPublishedFeedback()
        {
            
            List<Feedback> result = feedbackService.GetPublishedFeedback();           
            return Ok(result);
        }
    }
}
