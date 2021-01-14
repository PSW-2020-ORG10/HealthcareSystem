using EventStore.Dtos;
using EventStore.Events;
using EventStore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStore.Service
{
    public class AppointmentSchedulingEventService : IAppointmentSchedulingEventService
    {
        public readonly IAppointmentSchedulingEventRepository _appointmentSchedulingEventRepository;

        public AppointmentSchedulingEventService(IAppointmentSchedulingEventRepository appointmentSchedulingEventRepository)
        {
            _appointmentSchedulingEventRepository = appointmentSchedulingEventRepository;
        }

        public DomainEvent Create(DomainEvent domainEvent)
        {
            return _appointmentSchedulingEventRepository.Create(domainEvent);
        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return _appointmentSchedulingEventRepository.GetAll();
        }

        public long FindNextAttempt()
        {
            return _appointmentSchedulingEventRepository.FindNextAttempt();
        }

        public CountStepsEventDto GetStatisticsMinSteps()
        {
            return _appointmentSchedulingEventRepository.GetStatisticsMinSteps();
        }

        public CountStepsEventDto GetStatisticsMaxSteps()
        {
            return _appointmentSchedulingEventRepository.GetStatisticsMaxSteps();
        }
    }
}
