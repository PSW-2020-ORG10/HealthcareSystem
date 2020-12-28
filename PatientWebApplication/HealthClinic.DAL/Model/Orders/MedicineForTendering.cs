using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Orders
{
    public class MedicineForTendering : Entity
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int TenderId { get; set; }

        public MedicineForTendering() : base() { }

        public MedicineForTendering(int id, string name, int quantity, int tender) : base(id)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tender;
        }
        public MedicineForTendering(string name, int quantity, int tender)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tender;
        }
    }
}
