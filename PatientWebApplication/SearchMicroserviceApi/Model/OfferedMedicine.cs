using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class OfferedMedicines : Medicine
    {
        public double price { get; set; }

        public OfferedMedicines() { }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isComfirmed, double price) : base(id, name, quantity, description, room, doctorId, isComfirmed)
        {
            this.price = price;
        }

        public OfferedMedicines(int id, string name, int quantity, string description, List<ModelRoom> room, int doctorId, bool isComfirmed, double price, int prescriptionId) : base(id, name, quantity, description, room, doctorId, isComfirmed, prescriptionId)
        {
            this.price = price;
        }

    }
}
