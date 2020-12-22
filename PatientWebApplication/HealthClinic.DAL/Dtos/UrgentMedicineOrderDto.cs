using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class UrgentMedicineOrderDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Pharmacy { get; set; }
        public UrgentMedicineOrderDto() { }

        public UrgentMedicineOrderDto(string name, int quantity, String pharmacy)
        {
            Name = name;
            Quantity = quantity;
            Pharmacy = pharmacy;
        }
       
    }
}
