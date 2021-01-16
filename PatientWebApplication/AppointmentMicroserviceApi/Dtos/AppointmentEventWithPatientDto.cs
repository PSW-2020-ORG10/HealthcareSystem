using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Dtos
{
    public class AppointmentEventWithPatientDto
    {
        public MicroservicePatientUserDto Patient { get; set; }
        public int Step { get; set; }
        public string Action { get; set; }
        public string EndPoint { get; set; }
        public long Attempt { get; set; }

        public AppointmentEventWithPatientDto(MicroservicePatientUserDto patient, int step, string action, string endPoint, long attempt)
        {
            Patient = patient;
            Step = step;
            Action = action;
            EndPoint = endPoint;
            Attempt = attempt;
        }
    }
}
