using EventStore.Dtos;
using EventStore.Events;
using System.Collections.Generic;

namespace EventStore.Repository
{
    public interface IAppointmentSchedulingEventRepository
    {
        DomainEvent Create(DomainEvent domainEvent);
        long FindNextAttempt();
        List<AppointmentSchedulingEvent> GetAll();
    }
}