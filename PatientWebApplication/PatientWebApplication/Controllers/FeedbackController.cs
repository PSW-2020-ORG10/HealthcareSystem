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
using PatientWebApplication.Validators;

namespace PatientWebApplication.Controllers
{
    /// <summary>Class <c>FeedbackController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly MyDbContext dbContext;
        /// <value>Property <c>FeedbackService</c> represents the service used for handling business logic.</value>
        private FeedbackService FeedbackService { get; set; }

        /// <summary>This constructor injects the FeedbackController with matching FeedbackService.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public FeedbackController(MyDbContext context)
        {
            this.dbContext = context;
            FeedbackService = new FeedbackService(context);
        }


        [HttpGet]       // GET /api/feedback
        /// <summary> This method is for getting all feedback. </summary>
        /// <returns> List of all feedback. </returns>
        public IActionResult Get()
        {

            List<Feedback> result = FeedbackService.GetAll();           
            return Ok(result);
        }


        [HttpGet("published")]       // GET /api/feedback/published
        public IActionResult GetPublished()
        {
            
            List<Feedback> result = FeedbackService.GetPublished();           
            return Ok(result);
        }

        [HttpPost]      // POST /api/feedback Request body: {"message": "Some message", "isPublic": true, "isAnonymous": false}
        public IActionResult Create(FeedbackDto dto)
        {
            // validation in feedback validator, automatically called from startup

            PatientUser patient = dbContext.Patients.SingleOrDefault(patient => patient.id == 1);    // still no login, so patient set to created patient in database with id=1, this will be changed after
            if (patient == null)
            {
                return BadRequest();    // if any of the values is incorrect return bad request
            }

            Feedback feedback = FeedbackService.Create(dto);

            if (feedback == null)
            {
                return BadRequest();
            } else
            {
                return Ok();
            }

        }

        [HttpPut("{id}")]       // PUT /api/feedback/{id}
        public IActionResult Put(int id)
        {
            if(id < 0)
            {
                return BadRequest();
            }

            // checking if feedback exists in database
            Feedback result = FeedbackService.Publish(id);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
