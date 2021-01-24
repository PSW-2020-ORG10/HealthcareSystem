using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Service
{
    public interface IDomainEventService
    {
        DomainEvent Create(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll();
    }
}
