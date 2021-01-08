using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventStore.Repository
{
    public class DomainEventRepository : IDomainEventRepository
    {
        private readonly EventDbContext MyDbContext;

        public DomainEventRepository(EventDbContext dbContext)
        {
            MyDbContext = dbContext;
        }
        public IEnumerable<DomainEvent> GetAll(string eventType)
        {
            List<DomainEvent> domainEvents = new List<DomainEvent>();
            if(eventType.ToLower().Equals("feedbacksubmittedevent"))
            {
                MyDbContext.FeedbackSubmittedEvents.ToList().ForEach(@event => domainEvents.Add(@event));
            }

            return domainEvents;
        
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            var @event = (dynamic)domainEvent;
            if(@event is FeedbackSubmittedEvent)
            {
                MyDbContext.FeedbackSubmittedEvents.Add(@event);
            }

            MyDbContext.SaveChanges();
            return domainEvent;
           
        }
    }
}
