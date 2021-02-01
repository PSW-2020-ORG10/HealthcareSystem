using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventStore.Dtos
{
    public class AppointmentSchedulingEventDto
    {
        public int PatientId { get; set; }
        public int Step { get; set; }
        public string Action { get; set; }
        public string EndPoint { get; set; }

        public AppointmentSchedulingEventDto(int patientId, int step, string action, string endPoint)
        {
            PatientId = patientId;
            Step = step;
            Action = action;
            EndPoint = endPoint;
        }
    }
}
