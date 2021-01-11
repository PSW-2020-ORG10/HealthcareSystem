using System;

namespace UrgentMedicineOrderApi.Model
{
    public class MedicineWithQuantity : Entity
    {
        public String Name {get;set;}
        public int Quantity { get; set; }
        public String Description { get; set; }
        public MedicineWithQuantity() { }
        public MedicineWithQuantity(int id, String name, int quantity, String description) : base(id)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
        }
        public MedicineWithQuantity(String name, int quantity, String description)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
        }
    }
}
