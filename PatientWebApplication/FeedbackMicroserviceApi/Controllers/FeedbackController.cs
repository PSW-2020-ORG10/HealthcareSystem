﻿using FeedbackMicroserviceApi.Adapters;
using FeedbackMicroserviceApi.DbContextModel;
using FeedbackMicroserviceApi.Dtos;
using FeedbackMicroserviceApi.Model;
using FeedbackMicroserviceApi.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EventStore.EventDBContext;
using EventStore.Events;
using EventStore.Repository;
using EventStore.Service;


namespace FeedbackMicroserviceApi.Controllers
{
    /// <summary>Class <c>FeedbackController</c> handles requests sent from client app.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        /// <value>Property <c>FeedbackService</c> represents the service used for handling business logic.</value>
        private FeedbackService FeedbackService { get; set; }
        private FeedbackSubmittedEventService FeedbackSubmittedEventService { get; set; }

        /// <summary>This constructor injects the FeedbackController with matching FeedbackService.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public FeedbackController(MyDbContext context, EventDbContext eventDbContext = null)
        {
            FeedbackService = new FeedbackService(context);
            FeedbackSubmittedEventService = eventDbContext != null ? new FeedbackSubmittedEventService(new FeedbackSubmittedEventRepository(eventDbContext)) : null;
        }

        /// <summary> This method is calling <c>FeedbackService</c> to get list of all <c>Feedback</c>.  </summary>
        /// <returns> 200 Ok with list of all feedback. </returns>
        [HttpGet]       // GET /api/feedback
        [Authorize(Roles = "admin")]
        public IActionResult Get()
        {
            return Ok(FeedbackAdapter.FeedbackListToMicroserviceFeedbackDtoList(FeedbackService.GetAll()));
        }


        /// <summary> This method is calling <c>FeedbackService</c> to get list of all published <c>Feedback</c>. </summary>
        /// <returns> 200 Ok with list of published feedback. </returns>
        [HttpGet("published")]       // GET /api/feedback/published
        [AllowAnonymous] 
        public IActionResult GetPublished()
        {
            return Ok(FeedbackAdapter.FeedbackListToMicroserviceFeedbackDtoList(FeedbackService.GetPublished()));
        }


        /// <summary> This method determines if <c>FeedbackDto</c> provided <paramref name="dto"/> is valid for creating by calling <c>FeedbackValidator</c>
        /// automatically and sends it to <c>FeedbackService</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>. 
        /// </param>
        /// <returns> if fields from <paramref name="dto"/> are not valid 400 Bad Request also if created feedback is not null 200 Ok else 404 Bad Request.</returns>
        [HttpPost]      // POST /api/feedback Request body: {"message": "Some message", "isPublic": true, "isAnonymous": false}
        [Authorize(Roles = "patient")]
        public IActionResult Create(FeedbackDto dto)
        {
            Feedback feedback = FeedbackService.Create(dto);
            
            
            if (feedback == null)
            {
                return BadRequest();
            }
            else
            {

                CreateFeedbackSubmittedEvent(feedback);
                return Ok();
            }

        }

        private void CreateFeedbackSubmittedEvent(Feedback feedback)
        {
            if(FeedbackSubmittedEventService != null)
            {
                FeedbackSubmittedEventService.Create(new FeedbackSubmittedEvent(feedback.Id, feedback.Message, feedback.PatientId));
            }
        }

        /// <summary> This method determines if provided <paramref name="id"/> of feedback is valid, if <c>True</c> it sends it to <c>FeedbackService</c> to check out further business logic. </summary>
        /// <param name="id"><c>id</c> is id of feedback that needs to be published. 
        /// </param>
        /// <returns> If <paramref name="id"/> is not valid returns 400 Bad Request; if business logic is not valid, returns 404 Not Found, if feedback is successfully published, returns 200 OK with published feedback</returns>

        [HttpPut("{id}")]       // PUT /api/feedback/{id}
        [Authorize(Roles = "admin")]
        public IActionResult Put(int id)
        {
            if (id < 0)
            {
                return BadRequest();
            }

            // checking if feedback exists in database
            Feedback result = FeedbackService.Publish(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(FeedbackAdapter.FeedbackToMicroserviceFeedbackDto(result));
        }


    }
}
