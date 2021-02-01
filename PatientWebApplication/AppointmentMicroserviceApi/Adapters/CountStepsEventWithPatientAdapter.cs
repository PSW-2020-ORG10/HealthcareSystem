using AppointmentMicroserviceApi.Dtos;
using EventStore.Dtos;
using EventStore.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Adapters
{
    public static class CountStepsEventWithPatientAdapter
    {
        public static CountStepsEventWithPatientDto CountStepsEventDtoToCountStepsEventWithPatientDto(CountStepsEventDto dto)
        {
            return dto!=null ? new CountStepsEventWithPatientDto(AppointmentSchedulingEventToAppointmentEventWithPatientDto(dto.AppointmentSchedulingEvent), dto.CountSteps) : null;
        }

        private static AppointmentEventWithPatientDto AppointmentSchedulingEventToAppointmentEventWithPatientDto(AppointmentSchedulingEvent appointmentSchedulingEvent){
            MicroservicePatientUserDto patientUserDto = Utility.HttpRequests.GetPatientByIdAsync(appointmentSchedulingEvent.PatientId).Result;
            return new AppointmentEventWithPatientDto(patientUserDto, appointmentSchedulingEvent.Step, appointmentSchedulingEvent.Action, appointmentSchedulingEvent.EndPoint, appointmentSchedulingEvent.Attempt);
        }

    }
}
