using EventStore.Events;
using System;
using System.Collections.Generic;


namespace EventStore.Service
{
    public interface IDomainEventService
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll(String eventType);
    }
}
