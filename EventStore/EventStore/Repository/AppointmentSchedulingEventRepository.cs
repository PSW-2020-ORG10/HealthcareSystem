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
            List<long> successfulAppointmentsAttempts = new List<long>();
            foreach (AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if (appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Attempt);
                }
            }
            if (successfulAppointmentsAttempts.Count > 0)
            {

                var minEvent = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent => successfulAppointmentsAttempts.Contains(appointmentEvent.Attempt)).ToList()
                    .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                       .Select(grp => new
                       {
                           Attempt = grp.Key,
                           Count = grp.Count() - 2
                       })
                       .ToList().Aggregate(
                    (eventWithMinCount, currentEvent) =>
                        currentEvent.Count <= eventWithMinCount.Count ? currentEvent : eventWithMinCount);

                return new CountStepsEventDto(GetEventByAttempt(minEvent.Attempt), minEvent.Count);
            } else
            {
                return null;
            }
        }

        public CountStepsEventDto GetStatisticsMaxSteps()
        {
            List<long> successfulAppointmentsAttempts = new List<long>();
            foreach(AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if(appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Attempt);
                }
            }
            if (successfulAppointmentsAttempts.Count > 0)
            {
                var maxEvent = MyDbContext.AppointmentSchedulingEvents.Where(appointmentEvent => successfulAppointmentsAttempts.Contains(appointmentEvent.Attempt)).ToList()
                    .GroupBy(appointmentEvent => appointmentEvent.Attempt)
                       .Select(grp => new
                       {
                           Attempt = grp.Key,
                           Count = grp.Count() - 2
                       })
                       .ToList().Aggregate(
                    (eventWithMaxCount, currentEvent) =>
                        currentEvent.Count >= eventWithMaxCount.Count ? currentEvent : eventWithMaxCount);

                return new CountStepsEventDto(GetEventByAttempt(maxEvent.Attempt), maxEvent.Count);
            }
            else
            {
                return null;
            }
        }

        public double GetSuccessfulAttemptsRatio()
        {
            List<long> successfulAppointmentsAttempts = new List<long>();
            foreach (AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if (appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Attempt);
                }
            }

            int successfulAttemptsCount = successfulAppointmentsAttempts.Count();
  
            int allAttemptsCount = MyDbContext.AppointmentSchedulingEvents.ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).ToList().Count();
            
            return Math.Round(((double)successfulAttemptsCount / (double)allAttemptsCount),2);
        }

        public int GetMostCanceledStep()
        {
            List<long> successfulAppointmentsAttempts2 = new List<long>();
            foreach (AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                if (appointmentSchedulingEvent.Action.Equals("create"))
                {
                    successfulAppointmentsAttempts2.Add(appointmentSchedulingEvent.Attempt);
                }
            }
            List<int> unsuccessfulAppointmentsAttempts = new List<int>();
            foreach (AppointmentSchedulingEvent appointmentSchedulingEvent in MyDbContext.AppointmentSchedulingEvents.ToList())
            {
                /* if (!appointmentSchedulingEvent.Action.Equals("create"))
                 {
                     successfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Step);
                 }*/
                if (appointmentSchedulingEvent.Action.Equals("cancel") && !successfulAppointmentsAttempts2.Contains(appointmentSchedulingEvent.Attempt))
                {
                    unsuccessfulAppointmentsAttempts.Add(appointmentSchedulingEvent.Step);
                }
            }

            return unsuccessfulAppointmentsAttempts.Count > 0 ? unsuccessfulAppointmentsAttempts.GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : 0;
        }
    }
}
