using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using IntegrationWithPharmacies.FileProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Services
{
    public class TenderingService
    {
        private HttpService HttpService { get; }

        public TenderingService(MyDbContext context)
        {
            HttpService = new HttpService();
        }
        public Boolean PublishTender(TenderOrder tender)
        {
            try
            {
                HttpService.SendTender(CreateTender(tender));
                return true;
            }
            catch (Exception e) { return false; }
        }
        public String CreateTender(TenderOrder tender)
        {
            string tenderText = "";
            foreach(MedicineQuantity medicineQuantity in tender.MedicinesWithQuantity)
            {
                tenderText += medicineQuantity.MedicineName + ";" + medicineQuantity.Quantity + "!";
            }
            return tenderText +"&"+ tender.Date;

        }
    }
}
