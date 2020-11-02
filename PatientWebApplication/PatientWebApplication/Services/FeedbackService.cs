using Class_diagram.Model.Patient;
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
    

        public List<Feedback> GetPublishedFeedback() {
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
