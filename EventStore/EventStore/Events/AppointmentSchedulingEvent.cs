using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStore.Events
{
    public class AppointmentSchedulingEvent : DomainEvent
    {
        public int PatientId { get; set; }
        public int Step { get; set; }
        public string Action { get; set; }
        public string EndPoint { get; set; }
        public long Attempt { get; set; }

        public AppointmentSchedulingEvent(int patientId, int step, string action, string endPoint)
        {
            PatientId = patientId;
            Step = step;
            Action = action;
            EndPoint = endPoint;
        }

        public AppointmentSchedulingEvent(int patientId, int step, string action, string endPoint, long attempt)
        {
            PatientId = patientId;
            Step = step;
            Action = action;
            EndPoint = endPoint;
            Attempt = attempt;
        }
    }
}
