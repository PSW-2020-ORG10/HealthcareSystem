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
    public class FeedbackService 
    {
        private FeedbackRepository FeedbackRepository { get; set; }
        public FeedbackService(MyDbContext context)
        {
            FeedbackRepository = new FeedbackRepository(context);
        }

        //method for creating new feedback
        public Feedback Create(FeedbackDto dto)
        {
            PatientUser patient = new PatientUser();
            if (dto.IsAnonymous == false)      //if patient is not anynomous add to feedback else skip
            {
                patient = FeedbackRepository.FindPatient();
            }
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto, patient);
            return FeedbackRepository.Add(feedback);
        }

        //method for getting all feedback
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

        //method for publishing feedback
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
