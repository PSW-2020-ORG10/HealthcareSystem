using System;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Orders
{
    public class MedicineDescription : Entity
    {
        public String Name { get; set; }
        public String Description { get; set; }
        public int MedicineDescriptionId { get; set; }

        public MedicineDescription() : base() { }

        public MedicineDescription(int id, string name, String description, int medicineID) : base(id)
        {
            Name = name;
            Description = description;
            MedicineDescriptionId = medicineID;
        }
        public MedicineDescription(string name, String description, int medicineID)
        {
            Name = name;
            Description = description;
            MedicineDescriptionId = medicineID;
        }
    }
}
