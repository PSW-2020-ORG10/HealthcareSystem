using EventStore.Dtos;
using EventStore.Events;
using System.Collections.Generic;

namespace EventStore.Service
{
    public interface IAppointmentSchedulingEventService
    {
        DomainEvent Create(DomainEvent domainEvent);
        long FindNextAttempt();
        IEnumerable<DomainEvent> GetAll();
        public CountStepsEventDto GetStatisticsMinSteps();
        public CountStepsEventDto GetStatisticsMaxSteps();
        public double GetSuccessfulAttemptsRatio();
        public int GetMostCanceledStep();
        public double GetAverageStepsForSuccessfulAttempt();
        public double GetAverageStepsForUnsuccessfulAttempt();
        public CountStepsEventDto GetStatisticsMinStepsForCancelling();
        public CountStepsEventDto GetStatisticsMaxStepsForCancelling();
        public double GetMaxTime();
        public double GetMinTime();
        public double GetAverageTime();
        public int GetHowManySchedulesInMinimumSteps();
        public int GetHowManySchedulesInMediumSteps();
        public int GetHowManySchedulesInMoreSteps();
    }
}