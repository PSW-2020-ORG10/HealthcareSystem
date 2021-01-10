using System;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Orders
{
    public class UrgentMedicineOrder : Entity
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Pharmacy { get; set; }
        public String DateOfOrder { get; set; }

        public UrgentMedicineOrder() : base() { }

        public UrgentMedicineOrder(int id, string name, int quantity, String pharmacy, String dateOfOrder) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
            DateOfOrder = dateOfOrder;
        }
      
        public UrgentMedicineOrder(string name, int quantity, String pharmacy, String dateOfOrder)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
            DateOfOrder = dateOfOrder;
        }
    }
}