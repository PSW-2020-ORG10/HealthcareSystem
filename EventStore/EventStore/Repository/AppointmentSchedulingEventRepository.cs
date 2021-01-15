using EventStore.Dtos;
using EventStore.EventDBContext;
using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStore.Repository
{
    public class AppointmentSchedulingEventRepository : IAppointmentSchedulingEventRepository
    {
        private readonly EventDbContext MyDbContext;

        public AppointmentSchedulingEventRepository(EventDbContext dbContext)
        {
            MyDbContext = dbContext;
        }
        public DomainEvent Create(DomainEvent domainEvent)
        {
            MyDbContext.AppointmentSchedulingEvents.Add((dynamic)domainEvent);
            MyDbContext.SaveChanges();
            return domainEvent;
        }

        public IEnumerable<DomainEvent> GetAll()
        {
            return MyDbContext.AppointmentSchedulingEvents.ToList();
        }

        public long FindNextAttempt()
        {
            return MyDbContext.AppointmentSchedulingEvents.Count()==0 ? 0 : MyDbContext.AppointmentSchedulingEvents.ToList().Max(t => t.Attempt) + 1;
        }

        public AppointmentSchedulingEvent GetEventByAttempt(long attempt)
        {
            return MyDbContext.AppointmentSchedulingEvents.ToList().SingleOrDefault(appointment => appointment.Attempt == attempt && appointment.EndPoint.Equals("start"));
        }

        public CountStepsEventDto GetStatisticsMinSteps()
        {
            /*var minEvent = MyDbContext.AppointmentSchedulingEvents.GroupBy(appointmentEvent => appointmentEvent.Attempt)
                   .Select(grp => new {
                       Attempt = grp.Key,
                       Count = grp.Count()-2
                   }) 
                   .ToList().Aggregate(
                (eventWithMinCount, currentEvent) =>
                    currentEvent.Count <= eventWithMinCount.Count ? currentEvent : eventWithMinCount);

            return new CountStepsEventDto(GetEventByAttempt(minEvent.Attempt), minEvent.Count);*/
            List<long> successfulAppointmentsAttempts = new List<long>();
            /*        successifulAppointments = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent => appointmentEvent.Action == "create")
                .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                   .Select(grp => new
                   {
                       Attempt = unchecked((int)grp.Key)                  
                   })
                   .ToList();*/

            foreach (AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if (appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Attempt);
                }
            }

            var minEvent = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent => successfulAppointmentsAttempts.Contains(appointmentEvent.Attempt)).ToList()
                .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                   .Select(grp => new {
                       Attempt = grp.Key,
                       Count = grp.Count() - 2
                   })
                   .ToList().Aggregate(
                (eventWithMinCount, currentEvent) =>
                    currentEvent.Count <= eventWithMinCount.Count ? currentEvent : eventWithMinCount);

            return new CountStepsEventDto(GetEventByAttempt(minEvent.Attempt), minEvent.Count);
        }

        public CountStepsEventDto GetStatisticsMaxSteps()
        {
            List<long> successfulAppointmentsAttempts = new List<long>();
            /*        successifulAppointments = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent => appointmentEvent.Action == "create")
                .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                   .Select(grp => new
                   {
                       Attempt = unchecked((int)grp.Key)                  
                   })
                   .ToList();*/

            foreach(AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if(appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Attempt);
                }
            }

            var maxEvent = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent =>  successfulAppointmentsAttempts.Contains(appointmentEvent.Attempt)).ToList()
                .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                   .Select(grp => new {
                       Attempt = grp.Key,
                       Count = grp.Count()-2
                   })
                   .ToList().Aggregate(
                (eventWithMaxCount, currentEvent) =>
                    currentEvent.Count >= eventWithMaxCount.Count ? currentEvent : eventWithMaxCount);

            return new CountStepsEventDto(GetEventByAttempt(maxEvent.Attempt), maxEvent.Count);
        }
    }
}
