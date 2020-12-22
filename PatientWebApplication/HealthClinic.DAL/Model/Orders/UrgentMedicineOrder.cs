using System;
using System.Collections.Generic;
using System.Text;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Orders
{
    public  class UrgentMedicineOrder : Entity
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Pharmacy { get; set; }

        public UrgentMedicineOrder() : base() { }

        public UrgentMedicineOrder(int id, string name, int quantity, String pharmacy) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
        }
        public UrgentMedicineOrder(string name, int quantity, String pharmacy)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
        }
    }
}

