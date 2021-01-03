using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;

using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Adapters
{
    public class AppointmentAdapter
    {
        /// <summary>This method creates <c>AppointmentDto</c> from provided <paramref name="appointment"/>.</summary>
        /// <param name="appointment"><c>appointment</c> is <c>DoctorAppointment</c> that contains doctor's first name and surname, <c>Referral</c> and <c>Date</c>.</param>
        /// <returns> Created <c>AppointmentDto</c> </returns>
        public AppointmentDto AppointmentToAppointmenDto(DoctorAppointment appointment)
        {
            MicroserviceDoctorDto doctor = Utility.HttpRequests.GetDoctorByIdAsync(appointment.DoctorUserId).Result;
            return new AppointmentDto(doctor.Name + " " + doctor.Surname, appointment.referral, appointment.Date);
        }

        /// <summary>This method creates List of <c>AppointmentDto</c> from provided <paramref name="appointments"/>.</summary>
        /// <param name="appointments"><c>appointments</c> is List of <c>DoctorAppointment</c>.</param>
        /// <returns> Created List of <c>AppointmentDto</c>. </returns>
        public List<AppointmentDto> ConvertAppointmentListToAppointmentDtoList(List<DoctorAppointment> appointments)
        {
            List<AppointmentDto> appointmentsDto = new List<AppointmentDto>();
            foreach (DoctorAppointment appointment in appointments)
            {
                appointmentsDto.Add(AppointmentToAppointmenDto(appointment));
            }
            return appointmentsDto;
        }
    }
}
