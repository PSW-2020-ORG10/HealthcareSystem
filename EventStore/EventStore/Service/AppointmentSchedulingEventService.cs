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

        public List<AppointmentSchedulingEvent> GetAll()
        {
            return _appointmentSchedulingEventRepository.GetAll().ToList();
        }

        public long FindNextAttempt()
        {
            return _appointmentSchedulingEventRepository.FindNextAttempt();
        }

        private AppointmentSchedulingEvent GetEventByAttempt(long attempt)
        {
            return GetAll().SingleOrDefault(appointment => appointment.Attempt == attempt && appointment.EndPoint.Equals("start"));
        }

        public CountStepsEventDto GetStatisticsMinSteps()
        {
            if (GetSuccessfulAppointmentsAttempts().Count > 0)
            {
                var minEvent =GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Select(grp => new { Attempt = grp.Key, Count = grp.Count() - 2 }).ToList().Aggregate((eventWithMinCount, currentEvent) => currentEvent.Count <= eventWithMinCount.Count ? currentEvent : eventWithMinCount);
                return new CountStepsEventDto(GetEventByAttempt(minEvent.Attempt), minEvent.Count);
            }
            return null;
        }

        public CountStepsEventDto GetStatisticsMaxSteps()
        {
            if (GetSuccessfulAppointmentsAttempts().Count > 0)
            {
                var maxEvent = GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Select(grp => new { Attempt = grp.Key, Count = grp.Count() - 2 }).ToList().Aggregate((eventWithMaxCount, currentEvent) => currentEvent.Count >= eventWithMaxCount.Count ? currentEvent : eventWithMaxCount);
                return new CountStepsEventDto(GetEventByAttempt(maxEvent.Attempt), maxEvent.Count);
            }
            return null;
        }

        public double GetSuccessfulAttemptsRatio()
        {
            return Math.Round(((double)GetSuccessfulAppointmentsAttempts().Count() / (double)GetAll().GroupBy(appointmentEvent => appointmentEvent.Attempt).ToList().Count()), 2);
        }

        public int GetMostCanceledStep()
        {
            return GetAll().ToList().FindAll(appointmentEvent => appointmentEvent.Action.Equals("cancel") && !GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).Select(p => p.Step).ToList().Count > 0 ? GetAll().FindAll(appointmentEvent => appointmentEvent.Action.Equals("cancel") && !GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).Select(p => p.Step).ToList().GroupBy(i => i).OrderByDescending(grp => grp.Count()).Select(grp => grp.Key).First() : 0;
        }

        public double GetAverageStepsForSuccessfulAttempt()
        {
            return (GetSuccessfulAppointmentsAttempts().Count > 0) ? (((double)GetAll().FindAll(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).Count() / (double)GetSuccessfulAppointmentsAttempts().Count) - 2) : 0;
        }

        public double GetAverageStepsForUnsuccessfulAttempt()
        {
            return (GetCanceledAppointmentsAttempts().Except(GetSuccessfulAppointmentsAttempts()).Count() > 0) ? (((double)GetAll().FindAll(appointmentEvent => GetCanceledAppointmentsAttempts().Except(GetSuccessfulAppointmentsAttempts()).Contains(appointmentEvent.Attempt)).Count() / (double)GetCanceledAppointmentsAttempts().Except(GetSuccessfulAppointmentsAttempts()).Count()) - 1) : 0;
        }

        public CountStepsEventDto GetStatisticsMinStepsForCancelling()
        {
            List<long> successfulAppointmentsAttempts = GetSuccessfulAppointmentsAttempts();
            if (successfulAppointmentsAttempts.Count > 0)
            {
                var minEvent = GetAll().Where(appointmentEvent => GetCanceledAppointmentsAttempts().Except(successfulAppointmentsAttempts).Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Select(grp => new { Attempt = grp.Key, Count = grp.Count() - 1 }).ToList().Aggregate((eventWithMinCount, currentEvent) => currentEvent.Count <= eventWithMinCount.Count ? currentEvent : eventWithMinCount);
                return new CountStepsEventDto(GetEventByAttempt(minEvent.Attempt), minEvent.Count);
            }
            return null;
        }

        public CountStepsEventDto GetStatisticsMaxStepsForCancelling()
        {          
            List<long> successfulAppointmentsAttempts = GetSuccessfulAppointmentsAttempts();
            if (successfulAppointmentsAttempts.Count > 0)
            {
                var maxEvent = GetAll().Where(appointmentEvent => GetCanceledAppointmentsAttempts().Except(successfulAppointmentsAttempts).Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Select(grp => new { Attempt = grp.Key, Count = grp.Count() - 1 }).ToList().Aggregate((eventWithMaxCount, currentEvent) => currentEvent.Count >= eventWithMaxCount.Count ? currentEvent : eventWithMaxCount);
                return new CountStepsEventDto(GetEventByAttempt(maxEvent.Attempt), maxEvent.Count);
            }
            return null;
        }

        public double GetMaxTime()
        {
            return GetSuccessfulAppointmentsAttempts().Count > 0 ? FindMaximumTime() : 0;
        }

        private double FindMaximumTime()
        {
            double timeWasted = 0;
            foreach (var item in GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt))
            {
                timeWasted = (item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("create")).TimeStamp - item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("start")).TimeStamp).TotalSeconds > timeWasted ? (item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("create")).TimeStamp - item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("start")).TimeStamp).TotalSeconds : timeWasted;
            }
            return timeWasted;
        }

        public double GetMinTime()
        {
            return GetSuccessfulAppointmentsAttempts().Count > 0 ? FindMinimumTime() : 0;
        }

        private double FindMinimumTime()
        {
            double timeWasted = Double.MaxValue;
            foreach (var item in GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt))
            {
                timeWasted = (item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("create")).TimeStamp - item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("start")).TimeStamp).TotalSeconds < timeWasted ? (item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("create")).TimeStamp - item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("start")).TimeStamp).TotalSeconds : timeWasted;
            }
            return timeWasted;
        }

        public double GetAverageTime()
        {
            return GetSuccessfulAppointmentsAttempts().Count > 0 ? (double)GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).ToList().Select(item => (item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("create")).TimeStamp - item.ToList().SingleOrDefault(listItem => listItem.Action.Equals("start")).TimeStamp).TotalSeconds).Sum() / (double)GetSuccessfulAppointmentsAttempts().Count : 0;
        }
        public int GetHowManySchedulesInMinimumSteps()
        {                  
            return (GetSuccessfulAppointmentsAttempts().Count > 0) ? GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Where(grp => grp.Count() - 2 == 4).ToList().Count() : 0;                     
        }

        public int GetHowManySchedulesInMediumSteps()
        {
            return (GetSuccessfulAppointmentsAttempts().Count > 0) ? GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Where(grp => grp.Count() - 2 > 4 && grp.Count() - 2 <= 7).ToList().Count() : 0;
        }

        public int GetHowManySchedulesInMoreSteps()
        {
            return (GetSuccessfulAppointmentsAttempts().Count > 0) ? GetAll().Where(appointmentEvent => GetSuccessfulAppointmentsAttempts().Contains(appointmentEvent.Attempt)).ToList().GroupBy(appointmentEvent => appointmentEvent.Attempt).Where(grp => grp.Count() - 2 > 7).ToList().Count() : 0;        
        }

        private List<long> GetSuccessfulAppointmentsAttempts()
        {
            return GetAll().ToList().FindAll(appointmentEvent => appointmentEvent.Action.Equals("create")).Select(p => p.Attempt).ToList();
        }

        private List<long> GetCanceledAppointmentsAttempts()
        {
            return GetAll().ToList().FindAll(appointmentEvent => appointmentEvent.Action.Equals("cancel")).Select(p => p.Attempt).ToList();
        }
    }
}
