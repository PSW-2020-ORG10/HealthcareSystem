using PatientWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Services
{
    public static class FeedbackService
    {
        public static List<Feedback> GetPublished()
        {
            List<Feedback> result = new List<Feedback>();
            foreach (Feedback feedback in Program.Feedback)
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
