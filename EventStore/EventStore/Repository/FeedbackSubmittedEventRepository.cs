using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;
using EventStore.EventDBContext;
using System.Linq;

namespace EventStore.Repository
{
    public class FeedbackSubmittedEventRepository : IDomainEventRepository
    {
        private readonly EventDbContext MyDbContext;

        public FeedbackSubmittedEventRepository(EventDbContext dbContext)
        {
            MyDbContext = dbContext;
        }

        public DomainEvent Create(DomainEvent domainEvent)
        {
            MyDbContext.FeedbackSubmittedEvents.Add((dynamic)domainEvent);
            MyDbContext.SaveChanges();
            return domainEvent;
        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return MyDbContext.FeedbackSubmittedEvents.ToList();
        }
    }
}
