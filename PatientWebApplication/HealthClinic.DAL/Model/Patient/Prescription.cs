﻿using HealthClinic.CL.Model.Hospital;
using System;

namespace HealthClinic.CL.Model.Patient
{
    public class Prescription : Entity
    {
        public int patientsid { get; set; }
        public int medicineId { get; set; }
        public virtual Medicine medicine { get; set; }
        public bool isUsed { get; set; }
        public String comment { get; set; }

        public Prescription() : base() { }

        public Prescription(int id, int patientsid, Medicine medicine, bool isUsed, String comment) : base(id)
        {
            this.patientsid = patientsid;
            this.medicine = medicine;
            this.isUsed = isUsed;
            this.comment = comment;

        }

        public Prescription(int id, int patientsid, int medicineId, bool isUsed, String comment) : base(id)
        {
            this.patientsid = patientsid;
            this.medicineId = medicineId;
            this.isUsed = isUsed;
            this.comment = comment;

        }
    }
}
