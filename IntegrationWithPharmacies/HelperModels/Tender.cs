using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies
{
    public class Tender
    {
        public List<MedicineQuantity> MedicinesWithQuantity { get; set; }
        public String Date { get; set; }
        public Tender() { }

        public Tender(List<MedicineQuantity> medicinesWithQuantity, String date)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
        }

    }
}
