
using System;

namespace AppointmentMicroserviceApi.Model
{
    public class Appointment : Entity
    {
        public int DoctorUserId { get; set; }
        public TimeSpan Start { get; set; }
        public string Date { get; set; }
        public int PatientUserId { get; set; }
        public string RoomId { get; set; }
        public Appointment(int doctorUserId,  TimeSpan start, string date, int patientUserId, string roomid)
        {
            DoctorUserId = doctorUserId;
            Start = start;
            Date = date;
            PatientUserId = patientUserId;
            RoomId = roomid;
        }

        public Appointment(int id, int doctorUserId, TimeSpan start, string date, int patientUserId, string roomid) : base(id)
        {
            DoctorUserId = doctorUserId;
            Start = start;
            Date = date;
            PatientUserId = patientUserId;
            RoomId = roomid;
        }

        public Appointment(int id, TimeSpan start, string date, string roomid) : base(id)
        {
            Start = start;
            Date = date;
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
