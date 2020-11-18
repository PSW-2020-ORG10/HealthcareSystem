using HealthClinic.CL.Model.Hospital;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Patient
{
    public class Prescription : Entity
    {
        public int patientsid { get; set; }
        public virtual List<Medicine> Medicines { get; set; }
        public bool isUsed { get; set; }
        public String comment { get; set; }

        public Prescription() : base() { }

        public Prescription(int id, int patientsid, List<Medicine> medicines, bool isUsed, String comment) : base(id)
        {
            this.patientsid = patientsid;
            this.Medicines = medicines;
            this.isUsed = isUsed;
            this.comment = comment;

        }

        public Prescription(int id, int patientsid, bool isUsed, String comment) : base(id)
        {
            this.patientsid = patientsid;
            this.isUsed = isUsed;
            this.comment = comment;

        }
    }
}
