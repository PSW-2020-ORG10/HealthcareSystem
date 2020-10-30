using PatientWebApplication.Adapters;
using PatientWebApplication.Dtos;
using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    public static class FeedbackService
    {
        public static Feedback Create(FeedbackDto dto)
        {

            // id of new object is 1 if list empty, else max id + 1
            int id = Program.Feedback.Count > 0 ? Program.Feedback.Max(feedback => feedback.ID) + 1 : 1;
            Feedback feedback = FeedbackAdapter.FeedbackDtoToFeedback(dto);
            feedback.ID = id;
            Program.Feedback.Add(feedback);
            return feedback;
        }
    }
}
