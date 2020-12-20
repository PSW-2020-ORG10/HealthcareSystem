using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Model.Patient
{
    public class Appointment : Entity
    {
        public int DoctorUserId { get; set; }
        public virtual DoctorUser Doctor { get; set; }
        public TimeSpan Start { get; set; }
        public string Date { get; set; }
        public int PatientUserId { get; set; }
        public virtual PatientUser Patient { get; set; }
        public string RoomId { get; set; }
        public Appointment(int doctorUserId, DoctorUser doctor, TimeSpan start, string date, int patientUserId, PatientUser patient, string roomid)
        {
            DoctorUserId = doctorUserId;
            Doctor = doctor;
            Start = start;
            Date = date;
            PatientUserId = patientUserId;
            Patient = patient;
            RoomId = roomid;
        }

        public Appointment(int id, int doctorUserId, DoctorUser doctor, TimeSpan start, string date, int patientUserId, PatientUser patient, string roomid) : base(id)
        {
            DoctorUserId = doctorUserId;
            Doctor = doctor;
            Start = start;
            Date = date;
            PatientUserId = patientUserId;
            Patient = patient;
            RoomId = roomid;
        }

        public Appointment(int id, TimeSpan start, string date, PatientUser patient, DoctorUser doctor, string roomid) : base(id)
        {
            Doctor = doctor;
            Start = start;
            Date = date;
            Patient = patient;
            RoomId = roomid;
        }

        public Appointment(int id, TimeSpan start, string date, int patientId, int doctorId, string roomid) : base(id)
        {
            Start = start;
            Date = date;
            RoomId = roomid;
            PatientUserId = patientId;
            DoctorUserId = doctorId;
        }

        public Appointment() : base() { }
    }
}
