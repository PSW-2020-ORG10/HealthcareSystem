using HealthClinic.CL.Model.Patient;
using System;


namespace HealthClinic.CL.Model.Orders
{
    public class MedicineForOrdering :Entity 
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
        public int OrderId { get; set; }

        public MedicineForOrdering() : base() { }

        public MedicineForOrdering(int id, string name, int quantity,String description, int order) :base(id)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
            OrderId = order;
        }
        public MedicineForOrdering(string name, int quantity, String description, int order)
        {
            Name = name;
            Quantity = quantity;
            Description = description;
            OrderId = order;
        }

    }
}
