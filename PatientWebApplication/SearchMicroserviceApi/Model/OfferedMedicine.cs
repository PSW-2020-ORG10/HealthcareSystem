using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class OfferedMedicines : Medicine
    {
        public double Price { get; set; }

        public OfferedMedicines() { }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isComfirmed, double price) : base(id, name, quantity, description, room)
        {
            Price = price;
        }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isComfirmed, double price, int prescriptionId) : base(id, name, quantity, description, room)
        {
            Price = price;
        }
    }
}
