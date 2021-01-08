using System;


namespace EventStore.Events
{
    public class FeedbackSubmittedEvent : DomainEvent
    {
        public long FeedbackId { get; private set;}
        public String Content { get; private set;}

        public FeedbackSubmittedEvent(long feedbackId, String content)
        {
            FeedbackId = feedbackId;
            Content = content;
        }
    }
}
