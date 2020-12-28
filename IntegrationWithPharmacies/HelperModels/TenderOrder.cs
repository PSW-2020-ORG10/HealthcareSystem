using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class TenderOrder
    {
        public List<MedicineQuantity> MedicinesWithQuantity { get; set; }
        public String Date { get; set; }
        public TenderOrder() { }

        public TenderOrder(List<MedicineQuantity> medicinesWithQuantity, String date)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
        }

    }
}
