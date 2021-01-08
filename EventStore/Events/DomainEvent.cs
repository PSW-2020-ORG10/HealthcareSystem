using System;


namespace EventStore.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; set; }

        public DateTime TimeStamp { get; set; }
         public DomainEvent()
        {
            Id = Guid.NewGuid();
            TimeStamp = DateTime.UtcNow;
        }
    }
}
