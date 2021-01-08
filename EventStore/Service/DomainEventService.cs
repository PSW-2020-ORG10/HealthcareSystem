using EventStore.Events;
using EventStore.Repository;
using System.Collections.Generic;


namespace EventStore.Service
{
    public class DomainEventService : IDomainEventService
    {
        public readonly IDomainEventRepository IdomainEventRepository;

        public DomainEventService(IDomainEventRepository idomainEventRepository)
        {
            IdomainEventRepository = idomainEventRepository;
        }
        public IEnumerable<DomainEvent> GetAll(string eventType)
        {
            return IdomainEventRepository.GetAll(eventType);
        }

        public DomainEvent Save(DomainEvent domainEvent)
        {
            return IdomainEventRepository.Save(domainEvent);
        }
    }
}
