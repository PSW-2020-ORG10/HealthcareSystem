using System;

namespace HealthClinic.CL.Dtos
{
    public class MedicineDescriptionDto
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int MedicineDescriptionId { get; set; }

        public MedicineDescriptionDto() { }

        public MedicineDescriptionDto(string name, String description, int medicineDescriptionId)
        {
            Name = name;
            Description = description;
            MedicineDescriptionId = medicineDescriptionId;
        }
    }
}
