using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Repository
{
    public interface IDomainEventRepository
    {
        DomainEvent Create(DomainEvent domainEvent);
        IEnumerable<DomainEvent> GetAll();
    }
}
