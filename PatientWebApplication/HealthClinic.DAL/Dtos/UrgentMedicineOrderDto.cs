using System;

namespace HealthClinic.CL.Dtos
{
    public class UrgentMedicineOrderDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Pharmacy { get; set; }
        public String DateOfOrder { get; set; }

        public UrgentMedicineOrderDto(){ }

        public UrgentMedicineOrderDto(string name, int quantity, String pharmacy, String dateOfOrder)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
            DateOfOrder = dateOfOrder;
        }
    }
}