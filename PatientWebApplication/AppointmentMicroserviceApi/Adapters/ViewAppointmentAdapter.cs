using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Adapters
{
    public static class ViewAppointmentAdapter
    {
        public static MicroserviceDoctorAppointmentDto AppointmentToViewAppointmenDto(DoctorAppointment appointment)
        {
            return new MicroserviceDoctorAppointmentDto(Utility.HttpRequests.GetDoctorByIdAsync(appointment.DoctorUserId).Result, appointment.id, appointment.Start, appointment.Date, appointment.referral, appointment.RoomId);
        }

        public static List<MicroserviceDoctorAppointmentDto> AppointmentListToViewAppointmenDtoList(List<DoctorAppointment> appointments)
        {
            List<MicroserviceDoctorAppointmentDto> viewAppointments = new List<MicroserviceDoctorAppointmentDto>();
            foreach(DoctorAppointment appointment in appointments)
            {
                viewAppointments.Add(AppointmentToViewAppointmenDto(appointment));
            }
            return viewAppointments;
        }
    }
}
