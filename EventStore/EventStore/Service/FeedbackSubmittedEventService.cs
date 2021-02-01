using EventStore.Events;
using EventStore.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Service
{
    public class FeedbackSubmittedEventService : IDomainEventService
    {
        public readonly IDomainEventRepository IDomainEventRepository;

        public FeedbackSubmittedEventService(IDomainEventRepository iDomainEventRepository)
        {
            IDomainEventRepository = iDomainEventRepository;
        }

        public DomainEvent Create(DomainEvent domainEvent)
        {
            return IDomainEventRepository.Create(domainEvent);
        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return IDomainEventRepository.GetAll();
        }
    }
}
