using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Model.Pharmacy;
using HealthClinic.CL.Service;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class ReportText
    {
        public MyDbContext DbContext;
        private HelperFunctions HelperFunctions { get; }

        public ReportText(MyDbContext context)
        {
            HelperFunctions = new HelperFunctions();
        }
        public ReportText()
        {
           DbContext = new MyDbContext(new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options);
        }

        public String GetRegistredPharmacies()
        {
            StringBuilder stringBuilder = new StringBuilder();
           
            foreach (RegistrationInPharmacy registration in GetAllRegistrationInPharmacy())
            {
                stringBuilder.Append(registration.ApiKey + ";");
            }
            return stringBuilder.ToString();
        }

        private List<RegistrationInPharmacy>  GetAllRegistrationInPharmacy()
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var registrations = client.Get<List<RegistrationInPharmacy>>(new RestRequest("/api/registration"));
            return registrations.Data;
        }

        public String getReportText(DateOfOrder date)
        {
            StringBuilder stringBuilder = new StringBuilder();
            int totalQuatity = 0;

            foreach (Tender tender in GetAllTenders())
            {
                getText(date, tender,stringBuilder);
                totalQuatity += getQuantity(date, tender);
            }
            return stringBuilder.Append("\n\n   Total ordered quatity: " + totalQuatity + "\n").ToString();
        }
        private List<Tender> GetAllTenders()
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var tenders = client.Get<List<Tender>>(new RestRequest("/api/tender"));
            return tenders.Data;
        }
        private List<MedicineForTendering> GetAllMedicinesForTenders()
        {
            var client = new RestSharp.RestClient("http://localhost:54679");
            var medicines = client.Get<List<MedicineForTendering>>(new RestRequest("/api/tender/medicineForTender"));
            return medicines.Data;
        }

        public String getText(DateOfOrder date, Tender tender, StringBuilder stringBuilder)
        {
            foreach (MedicineForTendering medicine in GetAllMedicinesForTenders())
            {   
                if (isOrderInRequiredPeriod(medicine, date, tender))
                {
                    stringBuilder.Append("\n     Medicine name: " + medicine.Name + "\n     Ordered quantity: " + medicine.Quantity + " (Date:  " + tender.ActiveUntil.ToString() + ")\n");
                }
            }
            return stringBuilder.ToString();
        }
        private int getQuantity(DateOfOrder date, Tender tender)
        {
            return GetAllMedicinesForTenders().Where(medicine => isOrderInRequiredPeriod(medicine, date, tender)).Sum(medicine => medicine.Quantity);
        }
        private bool isOrderInRequiredPeriod(MedicineForTendering medicine, DateOfOrder date, Tender tender)
        {
            if (HelperFunctions.IsIdEqual(medicine.TenderId, tender.id) && HelperFunctions.CompareDates(tender.ActiveUntil, HelperFunctions.ConvertStringToDate(date.StartDate)) == 1 && HelperFunctions.CompareDates(tender.ActiveUntil, HelperFunctions.ConvertStringToDate(date.EndDate)) == -1 && tender.Closed) return true;
            return false;
        }
    }
}
