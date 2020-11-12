using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repositories;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Services
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


        /// <summary> This method converts <paramref name="dto"/> to <c>Feedback</c> using <c>FeedbackAdapter</c> and sends it to <c>FeedbackRepository</c>. </summary>
        /// <param name="dto"><c>dto</c> is Data Transfer Object of a <c>Feedback</c> that contains <c>Message</c>, <c>IsPublic</c>, <c>IsAnonymous</c> and <c>PatientId</c>. 
        /// </param>
        /// <returns>if patient exists returns successfully created feedback; otherwise, return <c>null</c></returns>
        public Feedback Create(FeedbackDto dto)
        { 
            PatientUser patient = FeedbackRepository.FindPatient();
            if(patient == null)
            {
                return null;
            }
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto, patient);
            return FeedbackRepository.Add(feedback);
        }


        /// <summary> This method is calling <c>FeedbackRepository</c> to get list of all<c>Feedback</c>. </summary>
        /// <returns> List of all feedback. </returns>
        public List<Feedback> GetAll()
        {
            return FeedbackRepository.GetAll();
        }

        /// <summary> This method is calling <c>FeedbackRepository</c> to get list of all published <c>Feedback</c>. </summary>
        /// <returns> List of all published feedback. </returns>
        public List<Feedback> GetPublished() {
            return FeedbackRepository.GetPublished();
        }

        /// <summary> This method calls <c>CheckForPublishing</c>, if feedback with provided <paramref name="id"/> is valid it sends it to <c>FeedbackRepository</c>. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>Feedback</c> that needs to be published.
        /// </param>
        /// <returns>null if feedback is not valid; otherwise, succesfully published feedback. </returns>
        public Feedback Publish(int id)
        {
            Feedback feedbackToPublish = CheckForPublishing(id);
            if(feedbackToPublish == null)
            {
                return null;
            }

            return FeedbackRepository.PublishFeedback(feedbackToPublish);
        }

        /// <summary> This method determines if feedback with id property that matches provided <paramref name="id"/> is valid for publishing. </summary>
        /// <param name="id"><c>id</c> is <c>id</c> of a <c>Feedback</c> that needs to be published.
        /// </param>
        /// <returns>null if parameter <c>IsPublic</c> or <c>IsPublished</c> of <c>feedbackToPublish</c> is false; otherwise, succesfully found feedback that satisfies business logic. </returns>
        private Feedback CheckForPublishing(int id)
        {
            Feedback feedback = FeedbackRepository.Find(id);
            if (feedback == null)
            {
                return null;
            }
            else if (feedback.IsPublic == false)
            {
                return null;
            }
            else if (feedback.IsPublished == true)
            {
                return null;
            }
            else
            {
                return feedback;
            }
        }
    }
}
