using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStore.Dtos
{
    public class CountStepsEventDto
    {
        public AppointmentSchedulingEvent AppointmentSchedulingEvent {get; set;}
        public int CountSteps { get; set; }
        public CountStepsEventDto(AppointmentSchedulingEvent appointmentSchedulingEvent, int countSteps)
        {
            AppointmentSchedulingEvent = appointmentSchedulingEvent;
            CountSteps = countSteps;
        }
    }
}
