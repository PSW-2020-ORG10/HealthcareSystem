using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Events
{
    public class FeedbackSubmittedEvent : DomainEvent
    {
        public int FeedbackID { get; set; }
        public String Message { get; set; }
        public int PatientID { get; set; }
        

        public FeedbackSubmittedEvent(int feedbackID, String message, int patientID)
        {
            FeedbackID = feedbackID;
            Message = message;
            PatientID = patientID;
            
        }
    }
}
