using HealthClinic.CL.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class MedicineForOrderingDto 
    {
        public String name { get; set; }
        public int quantity { get; set; }
        public String description { get; set; }
        public int orderId { get; set; }

        public MedicineForOrderingDto() { }

        public MedicineForOrderingDto(string name, int quantity, String description, int order)
        {
            this.name = name;
            this.quantity = quantity;
            this.description = description;
            this.orderId = order;
        }
    }
}
