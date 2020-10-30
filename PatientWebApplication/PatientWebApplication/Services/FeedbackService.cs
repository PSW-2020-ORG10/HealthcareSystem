using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    public static class FeedbackService
    {
        public static Feedback PublishFeedback(int id)
        {
            Feedback feedbackToPublish = Program.Feedback.Find(item => item.ID == id);
            if (feedbackToPublish == null)
            {
                return feedbackToPublish;
            }

            feedbackToPublish.IsPublished = true;
            return feedbackToPublish;
        }
    }
}
