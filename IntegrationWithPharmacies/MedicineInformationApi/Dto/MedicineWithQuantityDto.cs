using System;

namespace MedicineInformationApi.Dto
{
    public class MedicineWithQuantityDto
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }

        public MedicineWithQuantityDto() { }

        public MedicineWithQuantityDto(String name, int quantity, String description)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
        }
    }
}
