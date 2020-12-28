using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class MedicineForTenderingDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int TenderId { get; set; }

        public MedicineForTenderingDto() { }

        public MedicineForTenderingDto(string name, int quantity, int tender)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tender;
        }
    }
}
