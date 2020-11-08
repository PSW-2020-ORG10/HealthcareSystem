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


        /// <summary> This method is calling <c>FeedbackService</c> to get list of <c>Feedback</c> where paramter <c>IsPublished</c> is true. </summary>
        /// <returns> 200 Ok with list of published feedback. </returns>
        [HttpGet("published")]       // GET /api/feedback/published
        public IActionResult GetPublished()
        {
            
            List<Feedback> result = FeedbackService.GetPublished();           
            return Ok(result);
        }


        /// <summary> This method determines if <c>FeedbackDto</c> provided <paramref name="dto"/> is valid for creating by calling <c>FeedbackValidator</c> automatically and sends it to <c>FeedbackService</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>. 
        /// </param>
        /// <returns> if fields from <paramref name="dto"/> are not valid 404 Bad Request also if created feedback is not null 200 Ok else 404 Bad Request.</returns>
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
