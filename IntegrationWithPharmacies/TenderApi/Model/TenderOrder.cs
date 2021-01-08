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

        public String PharmacyApi { get; set; }
        public TenderOrder() { }

        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, String date)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
            Id = 0;
            PharmacyTenderOfferId = 0;
            PharmacyApi = "";
        }
        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, String date, int id, int pharmacyTenderOfferId, String pharmacyApi)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Date = date;
            Id = id;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
            PharmacyApi = pharmacyApi;
        }
        public TenderOrder(List<MedicineTenderOffer> medicinesWithQuantity, int id, int pharmacyTenderOfferId, String pharmacyApi)
        {
            MedicinesWithQuantity = medicinesWithQuantity;
            Id = id;
            PharmacyTenderOfferId = pharmacyTenderOfferId;
            PharmacyApi = pharmacyApi;
        }
    }
}
