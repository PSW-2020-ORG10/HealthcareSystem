using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Repository
{
    public interface IDomainEventRepository
    {
        DomainEvent Save(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll(String eventType);
    }
}
