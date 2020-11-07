using Class_diagram.Model.Patient;
using PatientWebApplication.Adapters;
using PatientWebApplication.Dtos;
using PatientWebApplication.Models;
using PatientWebApplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    /// <summary>Class <c>FeedbackService</c> handles feedback business logic.
    /// </summary>
    public class FeedbackService 
    {
        /// <value>Property <c>FeedbackRepository</c> represents the repository used for data access.</value>
        private FeedbackRepository FeedbackRepository { get; set; }
        /// <summary>This constructor injects the FeedbackService with matching FeedbackRepository.</summary>
        /// <param name="context"><c>context</c> is type of <c>DbContext</c>, and it's used for accessing MYSQL database.</param>
        public FeedbackService(MyDbContext context)
        {
            FeedbackRepository = new FeedbackRepository(context);
        }


        /// <summary> This method converts <c>FeedbackDto</c> <paramref name="dto"/> to <c>Feedback</c> using <c>FeedbackAdapter</c> and sends it to <c>FeedbackRepository</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>. 
        /// </param>
        /// <returns> succesfully created <c>Feedback</c>.</returns>
        public Feedback Create(FeedbackDto dto)
        {
            PatientUser patient = new PatientUser();
            if (dto.IsAnonymous == false)      
            {
                patient = FeedbackRepository.FindPatient();
            }
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto, patient);
            return FeedbackRepository.Add(feedback);
        }


        /// <summary> This method is for getting all feedback and sends it to <c>FeedbackRepository</c>. </summary>
        /// <returns> List of all feedback which contains all feedback. </returns>
        public List<Feedback> GetAll()
        {
            return FeedbackRepository.GetAll();
        }

        //method for getting all published feedback
        public List<Feedback> GetPublished() {
            List<Feedback> result = new List<Feedback>();
            foreach(Feedback feedback in FeedbackRepository.GetAll())
            {
                if (feedback.IsPublished)
                {
                    result.Add(feedback);
                }
            }
            return result;

        }

        /// <summary> This method determines if feedback with id property that matches provided <paramref name="id"/> is valid for publishing and sends it to <c>FeedbackRepository</c>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>Feedback</c> that needs to be published.
        /// </param>
        /// <returns>null if parameter <c>IsPublic</c> or <c>IsPublished</c> of <c>feedbackToPublish</c> is false; otherwise, succesfully published feedback. </returns>
        public Feedback Publish(int id)
        {
            Feedback feedbackToPublish = FeedbackRepository.Find(id);
            if (feedbackToPublish == null)
            {
                return null;
            }else if(feedbackToPublish.IsPublic == false)
            {
                return null;
            }else if(feedbackToPublish.IsPublished == true)
            {
                return null;
            }
            return FeedbackRepository.PublishFeedback(feedbackToPublish);
        }
    }
}
