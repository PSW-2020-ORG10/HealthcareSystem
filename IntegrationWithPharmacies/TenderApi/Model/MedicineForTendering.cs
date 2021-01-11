using System;

namespace TenderApi.Model
{
    public class MedicineForTendering : Entity
    {
        public String Name { get; set; }
        public int Quantity { get; set; }
        public int TenderId { get; set; }

        public MedicineForTendering() : base() { }

        public MedicineForTendering(int id, string name, int quantity, int tenderId) : base(id)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tenderId;
        }
        public MedicineForTendering(string name, int quantity, int tenderId)
        {
            Name = name;
            Quantity = quantity;
            TenderId = tenderId;
        }
    }
}
