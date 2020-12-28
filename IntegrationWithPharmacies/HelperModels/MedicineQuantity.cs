using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class MedicineQuantity
    {
        public String MedicineName { get; set; }
        public int Quantity { get; set; }
        public MedicineQuantity() { }

        public MedicineQuantity(String medicineName, int quantity)
        {
            MedicineName = medicineName;
            Quantity = quantity;
        }
    }
}
