using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using System;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Dtos
{
    public class MicroserviceDoctorAppointmentDto : DoctorAppointment
    {   
        public MicroserviceDoctorDto Doctor { get; set; }

        public MicroserviceDoctorAppointmentDto(MicroserviceDoctorDto doctor, int id, TimeSpan time, string date, int patientId, int doctorId, List<Referral> referrals, string roomid) : base(id, time, date, patientId, doctorId, referrals, roomid)
        {
            Doctor = doctor;
        }
        public MicroserviceDoctorAppointmentDto(MicroserviceDoctorDto doctor, int id, TimeSpan time, string date, List<Referral> referrals, string roomid) : base(id, time, date, referrals, roomid)
        {
            Doctor = doctor;
        }
    }
}
