using System;


namespace HealthClinic.CL.Dtos
{
    public class MedicineForOrderingDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
        public int OrderId { get; set; }

        public MedicineForOrderingDto() { }
        public MedicineForOrderingDto(string name, int quantity, String description, int order)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
            OrderId = order;
        }
    }
}
