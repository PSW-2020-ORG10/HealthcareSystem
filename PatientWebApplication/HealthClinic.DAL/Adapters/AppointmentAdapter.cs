using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class AppointmentAdapter
    {
        public AppointmentDto AppointmentToAppointmenDto(DoctorAppointment appointment)
        {
            return new AppointmentDto(appointment.Doctor.firstName + " " + appointment.Doctor.secondName, appointment.referral, appointment.Date);
        }

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
