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
        }
    }
}
