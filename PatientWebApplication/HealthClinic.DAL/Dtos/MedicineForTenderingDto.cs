using System;

namespace HealthClinic.CL.Dtos
{
    public class MedicineForTenderingDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int TenderId { get; set; }

        public MedicineForTenderingDto() { }

        public MedicineForTenderingDto(string name, int quantity, int tenderId)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tenderId;
        }
    }
}
