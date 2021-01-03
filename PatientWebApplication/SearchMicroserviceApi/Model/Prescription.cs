using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class Prescription : Entity
    {
        public int patientsid { get; set; }
        public virtual List<Medicine> Medicines { get; set; }
        public bool isUsed { get; set; }
        public string comment { get; set; }
        public int DoctorId { get; set; }

        public Prescription() : base() { }

        public Prescription(int id, int patientsid, List<Medicine> medicines, bool isUsed, string comment) : base(id)
        {
            this.patientsid = patientsid;
            Medicines = medicines;
            this.isUsed = isUsed;
            this.comment = comment;

        }

        public Prescription(int id, int patientsid, bool isUsed, string comment) : base(id)
        {
            this.patientsid = patientsid;
            this.isUsed = isUsed;
            this.comment = comment;

        }

        public Prescription(int id, int patientsid, List<Medicine> medicines, bool isUsed, string comment, int doctorId) : base(id)
        {
            this.patientsid = patientsid;
            Medicines = medicines;
            this.isUsed = isUsed;
            this.comment = comment;
            DoctorId = doctorId;

        }
    }
}
