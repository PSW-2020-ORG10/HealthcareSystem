using Class_diagram.Model.Patient;
using PatientWebApplication.Adapters;
using PatientWebApplication.Dtos;
using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        //method for creating new feedback
        public Feedback Create(FeedbackDto dto)
        {
            PatientUserWeb patient = new PatientUserWeb();
            if (dto.IsAnonymous == false)      //if patient is not anynomous add to feedback else skip
            {
                patient = dbContext.Patients.SingleOrDefault(patient => patient.id == 1); // still no login, so patient set to created patient in database with id=1, this will be changed after
            }
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto, patient);
            dbContext.Feedbacks.Add(feedback);
            dbContext.SaveChanges();
            return feedback;
        }
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
