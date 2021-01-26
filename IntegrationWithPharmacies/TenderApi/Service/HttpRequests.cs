using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TenderApi.Model;

namespace TenderApi.Service
{
    public class HttpRequests
    {
        private static readonly string medicineInformationUrl = Startup.Configuration["MedicineInformationApi"];
        private static readonly string pharmacyRegistrationUrl = Startup.Configuration["PharmacyRegistrationApi"];

        public HttpRequests() { }
        public async Task CreateNewMedicineWithQuantityAsync(MedicineTenderOffer medicineTenderOffer)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CreateMedicineTenderOfferObjectd(medicineTenderOffer), Formatting.Indented), Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync($"{medicineInformationUrl}api/medicineWithQuantity", content);
        }

        private static Dictionary<string, object> CreateMedicineTenderOfferObjectd(MedicineTenderOffer medicineTenderOffer)
        {
            return new Dictionary<string, object>
            {
                {"medicineDescription", new MedicineDescription(medicineTenderOffer.MedicineName, "")}, {"quantity",  medicineTenderOffer.AvailableQuantity }
            };
        }

        public static List<MedicineInformation> GetAllMedicinesWithQuantity()
        {
            return new RestClient(medicineInformationUrl).Get<List<MedicineInformation>>(new RestRequest("api/medicineWithQuantity")).Data;
        }

        public void UpdateMedicine(MedicineTenderOffer medicineTenderOffer, MedicineInformation medicine)
        {
            new RestClient(medicineInformationUrl).Get<List<MedicineInformation>>(new RestRequest("api/medicineWithQuantity/" + medicine.Id + "/" + medicineTenderOffer.AvailableQuantity));
        }
        public void UploadReportFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8086/download/file/http"), "POST", complete);
            client.Dispose();
        }
        public static List<RegistrationInPharmacy> GetRegistrationsInPharmaciesAll()
        {
            return new RestClient(pharmacyRegistrationUrl).Get<List<RegistrationInPharmacy>>(new RestRequest("api/registration")).Data;
        }
        public static IRestResponse<List<MedicineName>> FormMedicineFromIsaRequest()
        {
            return new RestClient("http://localhost:8086").Get<List<MedicineName>>(new RestRequest("/medicineRequested"));
        }
    }
}
