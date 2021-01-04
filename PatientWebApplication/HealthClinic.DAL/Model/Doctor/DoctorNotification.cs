using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Doctor
{
    public class DoctorNotification : StringData
    {
        public int DoctorUserId { get; set; }
        public virtual DoctorUser DoctorUser { get; set; }

        public DoctorNotification(int id, string data, DoctorUser doctor) : base(id, data)
        {
            Data = data;
            DoctorUserId = doctor.id;
            DoctorUser = doctor;
        }

        public DoctorNotification(int id, string data, int doctorId) : base(id, data)
        {
            Data = data;
            DoctorUserId = doctorId;
        }

        public DoctorNotification(int id, string data) : base(id, data)
        {
            Data = data;
        }

        public DoctorNotification(string data) : base(data)
        {

        }

        public DoctorNotification() : base()
        {

        }
    }
}
