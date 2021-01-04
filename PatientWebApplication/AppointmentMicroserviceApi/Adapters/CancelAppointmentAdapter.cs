using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Adapters
{
    public static class CancelAppointmentAdapter
    {
        /// <summary>This method creates <c>AppointmentDto</c> from provided <paramref name="appointment"/>.</summary>
        /// <param name="appointment"><c>appointment</c> is <c>DoctorAppointment</c> that contains doctor's first name and surname, <c>Referral</c> and <c>Date</c>.</param>
        /// <returns> Created <c>AppointmentDto</c> </returns>
        public static MicroserviceAppointmentDto AppointmentToAppointmenDto(DoctorAppointment appointment)
        {
            MicroserviceDoctorDto doctor = Utility.HttpRequests.GetDoctorByIdAsync(appointment.DoctorUserId).Result;
            return new MicroserviceAppointmentDto(appointment.PatientUserId, appointment.Date, appointment.CancelDateString, appointment.IsCanceled);
        }

        /// <summary>This method creates List of <c>AppointmentDto</c> from provided <paramref name="appointments"/>.</summary>
        /// <param name="appointments"><c>appointments</c> is List of <c>DoctorAppointment</c>.</param>
        /// <returns> Created List of <c>AppointmentDto</c>. </returns>
        public static List<MicroserviceAppointmentDto> ConvertAppointmentListToAppointmentDtoList(List<DoctorAppointment> appointments)
        {
            List<MicroserviceAppointmentDto> appointmentsDto = new List<MicroserviceAppointmentDto>();
            foreach (DoctorAppointment appointment in appointments)
            {
                appointmentsDto.Add(AppointmentToAppointmenDto(appointment));
            }
            return appointmentsDto;
        }
    }
}
