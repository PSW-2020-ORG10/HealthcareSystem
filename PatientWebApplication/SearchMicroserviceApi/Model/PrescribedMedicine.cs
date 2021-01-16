using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Model
{
    public class PrescribedMedicine : Entity
    {
        public int MedicineId { get; set; }
        public virtual Medicine Medicine { get; set; }
        public int Quantity{ get; set; }
        public string HowToUse { get; set; }
        public int PrescriptionId { get; set; }

        public PrescribedMedicine(int id, int medicineId, int quantity, string howToUse, int prescriptionId) : base(id)
        {
            MedicineId = medicineId;
            Quantity = quantity;
            HowToUse = howToUse;
            PrescriptionId = prescriptionId;
        }
    }
}
