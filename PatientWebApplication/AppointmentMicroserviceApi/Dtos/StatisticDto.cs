using EventStore.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Dtos
{
    public class StatisticDto
    {
        public CountStepsEventWithPatientDto MinSteps { get; set; }
        public CountStepsEventWithPatientDto MaxSteps { get; set; }
        public double SuccessfulAttemptsRatio { get; set; }
        public double MostCanceledStep { get; set; }
        public double AverageStepsForSuccessfulAttempt { get; set; }
        public double AverageStepsForUnsuccessfulAttempt { get; set; }
        public CountStepsEventWithPatientDto MinStepsForCancelling { get; set; }
        public CountStepsEventWithPatientDto MaxStepsForCancelling { get; set; }
        public double MaxTime { get; set; }
        public double MinTime { get; set; }
        public double AverageTime { get; set; }
        public int HowManySchedulesInMinimumSteps { get; set; }
        public int HowManySchedulesInMediumSteps { get; set; }
        public int HowManySchedulesInMoreSteps { get; set; }

        public StatisticDto(CountStepsEventWithPatientDto minSteps, CountStepsEventWithPatientDto maxSteps, double successfulAttemptsRatio, double mostCanceledStep, double averageStepsForSuccessfulAttempt, double averageStepsForUnsuccessfulAttempt, CountStepsEventWithPatientDto minStepsForCancelling, CountStepsEventWithPatientDto maxStepsForCancelling, double maxTime, double minTime, double averageTime, int howManyScheduledInMinSteps, int howManySchedulesInMediumSteps, int howManySchedulesInMoreSteps)
        {
            MinSteps = minSteps;
            MaxSteps = maxSteps;
            SuccessfulAttemptsRatio = successfulAttemptsRatio;
            MostCanceledStep = mostCanceledStep;
            AverageStepsForSuccessfulAttempt = averageStepsForSuccessfulAttempt;
            AverageStepsForUnsuccessfulAttempt = averageStepsForUnsuccessfulAttempt;
            MinStepsForCancelling = minStepsForCancelling;
            MaxStepsForCancelling = maxStepsForCancelling;
            MaxTime = maxTime;
            MinTime = minTime;
            AverageTime = averageTime;
            HowManySchedulesInMinimumSteps = howManyScheduledInMinSteps;
            HowManySchedulesInMediumSteps = howManySchedulesInMediumSteps;
            HowManySchedulesInMoreSteps = howManySchedulesInMoreSteps;
        }
    }
}
