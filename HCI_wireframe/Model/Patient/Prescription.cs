using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Patient
{
    class Prescription : Entity
    {
        public int patientsid { get; set; }
        public Medicine medicine { get; set; }
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
    }
}
