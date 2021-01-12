using System;
using System.Collections.Generic;
using System.Text;

namespace EventStore.Events
{
    public abstract class DomainEvent
    {
        public Guid ID { get; set; }

        public DateTime TimeStamp { get; set; }
        public DomainEvent()
        {
            ID = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
    }
}
