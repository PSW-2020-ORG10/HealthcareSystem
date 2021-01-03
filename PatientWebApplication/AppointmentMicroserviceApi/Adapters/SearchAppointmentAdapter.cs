using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Adapters
{
    public static class SearchAppointmentAdapter
    {
        public static MicroserviceSearchAppointmentDto AppointmentToSearchAppointmenDto(DoctorAppointment appointment)
        {
            return new MicroserviceSearchAppointmentDto(Utility.HttpRequests.GetDoctorByIdAsync(appointment.DoctorUserId).Result, appointment.Date, appointment.RoomId);
        }

        public static List<MicroserviceSearchAppointmentDto> AppointmentListToSearchAppointmenDtoList(List<DoctorAppointment> appointments)
        {
            List<MicroserviceSearchAppointmentDto> microserviceSearchAppointmentDtos = new List<MicroserviceSearchAppointmentDto>();
            foreach (DoctorAppointment appointment in appointments)
            {
                microserviceSearchAppointmentDtos.Add(AppointmentToSearchAppointmenDto(appointment));
            }
            return microserviceSearchAppointmentDtos;
        }
    }
}
