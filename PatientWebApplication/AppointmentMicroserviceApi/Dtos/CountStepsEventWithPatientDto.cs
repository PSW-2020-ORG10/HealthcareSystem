using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Dtos
{
    public class CountStepsEventWithPatientDto
    {
        public AppointmentEventWithPatientDto AppointmentEventWithPatientDto { get; set; }
        public int CountSteps { get; set; }
        public CountStepsEventWithPatientDto(AppointmentEventWithPatientDto appointmentEventWithPatientDto, int countSteps)
        {
            AppointmentEventWithPatientDto = appointmentEventWithPatientDto;
            CountSteps = countSteps;
        }
    }
}
