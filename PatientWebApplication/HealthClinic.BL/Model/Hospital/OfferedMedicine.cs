using HealthClinic.BL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.BL.Model.Hospital
{
    public class OfferedMedicines : Medicine
    {
        public double price { get; set; }

        public OfferedMedicines() { }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, DoctorUser doctor, bool isComfirmed, double price) : base(id, name, quantity, description, room, doctor, isComfirmed)
        {
            this.price = price;
        }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isComfirmed, double price) : base(id, name, quantity, description, room, doctorId, isComfirmed)
        {
            this.price = price;
        }

    }
}
