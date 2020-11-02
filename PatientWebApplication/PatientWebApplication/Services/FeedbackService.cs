using Class_diagram.Model.Patient;
using PatientWebApplication.Adapters;
using PatientWebApplication.Dtos;
using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    public class FeedbackService 
    {
        private readonly MyDbContext dbContext;
        public FeedbackService(MyDbContext context)
        {
            dbContext = context;
        }


        public Feedback Create(FeedbackDto dto)
        {
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
            return feedback;

        //method for getting all feedback
        public List<Feedback> GetAll()
        {
            List<Feedback> result = new List<Feedback>();
            dbContext.Feedbacks.ToList().ForEach(feedback => result.Add(feedback));
            return result;
        }

        //method for getting all published feedback
        public List<Feedback> GetPublished() {
            List<Feedback> result = new List<Feedback>();
            foreach(Feedback feedback in dbContext.Feedbacks.ToList())
            {
                if (feedback.IsPublished)
                {
                    result.Add(feedback);
                }
            }
            return result;

        }
    }
}
