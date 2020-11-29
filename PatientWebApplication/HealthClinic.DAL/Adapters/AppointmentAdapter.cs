using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class AppointmentAdapter
    {
        /// <summary>This method creates <c>AppointmentDto</c> from provided <paramref name="appointment"/>.</summary>
        /// <param name="appointment"><c>appointment</c> is <c>DoctorAppointment</c> that contains doctor's first name and surname, <c>Referral</c> and <c>Date</c>.</param>
        /// <returns> Created <c>AppointmentDto</c> </returns>
        public AppointmentDto AppointmentToAppointmenDto(DoctorAppointment appointment)
        {
            return new AppointmentDto(appointment.Doctor.firstName + " " + appointment.Doctor.secondName, appointment.referral, appointment.Date);
        }

        /// <summary>This method creates List of <c>AppointmentDto</c> from provided <paramref name="appointments"/>.</summary>
        /// <param name="appointments"><c>appointments</c> is List of <c>DoctorAppointment</c>.</param>
        /// <returns> Created List of <c>AppointmentDto</c>. </returns>
        public List<AppointmentDto> ConvertAppointmentListToAppointmentDtoList(List<DoctorAppointment> appointments)
        {
            List<AppointmentDto> appointmentsDto = new List<AppointmentDto>();
            AppointmentAdapter adapter = new AppointmentAdapter();
            foreach (DoctorAppointment appointment in appointments)
            {
                appointmentsDto.Add(adapter.AppointmentToAppointmenDto(appointment));
            }
            return appointmentsDto;
        }
    }
}
