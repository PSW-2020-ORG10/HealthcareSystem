using System;

namespace TenderApi.Model
{
    public class MedicineDescription
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int MedicineInformationId { get; set; }

        public MedicineDescription() { }
        public MedicineDescription(String name, String description)
        {
            Name = name;
            Description = description;
        }

        public MedicineDescription(String name, String description, int medicineInformationId)
        {
            Name = name;
            Description = description;
            MedicineInformationId = medicineInformationId;
        }
    }
}
