using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Hospital
{
    class OfferedMedicines : Medicine
    {
        public double price { get; set; }

        public OfferedMedicines()  { }

        public OfferedMedicines(int id, String name, int quantity, string description, List<String> room, DoctorUser doctor, Boolean isComfirmed, double price) : base(id, name, quantity, description, room, doctor, isComfirmed)
        {
            this.price = price;
        }

    }
}
