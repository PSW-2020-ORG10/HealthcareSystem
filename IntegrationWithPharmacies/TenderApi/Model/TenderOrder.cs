using System;
using System.Collections.Generic;

namespace TenderApi.Model
{
    public class TenderOrder
    {
        public List<MedicineTenderOffer> MedicinesWithQuantity { get; set; }
        public String Date { get; set; }
        public int Id { get; set; }
        public int PharmacyTenderOfferId { get; set; }
        public String PharmacyName { get; set; }
        public TenderOrder() { }

        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, String date)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
            Id = 0;
            PharmacyTenderOfferId = 0;
            PharmacyName = "";
        }
        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, String date, int id, int pharmacyTenderOfferId, String pharmacyName)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
            Id = id;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
            PharmacyName = pharmacyName;
        }
        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, int id, int pharmacyTenderOfferId, String pharmacyName)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Id = id;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
            PharmacyName = pharmacyName;
        }
    }
}
