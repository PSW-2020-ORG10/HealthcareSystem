using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace HealthClinic.CL.Model.Orders
{
    public class MedicineForOrdering :Entity 
    {
        public String name { get; set; }
        public int quantity { get; set; }
        public String description { get; set; }
        public int orderId { get; set; }

        public MedicineForOrdering() : base() { }

        public MedicineForOrdering(int id, string name, int quantity,String description, int order) :base(id)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.orderId = order;
        } 

    }
}
