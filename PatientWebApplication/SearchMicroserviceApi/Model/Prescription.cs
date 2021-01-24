using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class Prescription : Entity
    {
        public int Patientsid { get; set; }
        public virtual List<PrescribedMedicine> Medicines { get; set; }
        public bool IsUsed { get; set; }
        public string Comment { get; set; }
        public int DoctorId { get; set; }
        public int AppointmentId { get; set; }

        public Prescription() : base() { }

        public Prescription(int id, int patientsid, List<PrescribedMedicine> medicines, bool isUsed, string comment) : base(id)
        {
            Patientsid = patientsid;
            Medicines = medicines;
            IsUsed = isUsed;
            Comment = comment;
        }

        public Prescription(int id, int patientsid, bool isUsed, string comment) : base(id)
        {
            Patientsid = patientsid;
            IsUsed = isUsed;
            Comment = comment;
        }

        public Prescription(int id, int patientsid, List<PrescribedMedicine> medicines, bool isUsed, string comment, int doctorId, int appointmentId) : base(id)
        {
            Patientsid = patientsid;
            Medicines = medicines;
            IsUsed = isUsed;
            Comment = comment;
            DoctorId = doctorId;
            AppointmentId = appointmentId;
        }
    }
}
