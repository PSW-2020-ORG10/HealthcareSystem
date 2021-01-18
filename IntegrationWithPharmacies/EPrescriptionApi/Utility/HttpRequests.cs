using EPrescriptionApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EPrescriptionApi.Utility
{
    public class HttpRequests
    {
        private static readonly string MedicineInformationUrl = Startup.Configuration["MedicineInformationApi"];
        private static readonly string UsersServiceUrl = Startup.Configuration["UserMicroServiceApi"];
        private static readonly string PharmacyRegistrationUrl = Startup.Configuration["PharmacyRegistrationApi"];

        public HttpRequests() { }
    
        public void UploadPrescriptionFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8086/download/prescription/http"), "POST", complete);
            client.Dispose();
        }

        public List<MedicineName> GetAllMedicinesFromDatabase()
        {
            return new RestClient(MedicineInformationUrl).Get<List<MedicineName>>(new RestRequest("/api/medicineWithQuantity/all")).Data;
        }

        public static String FormMedicineAvailabilityRequest(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8086/medicinePharmacy/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();

        }
        public static string FormMedicineDescriptionRequest(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8086/description/medicine/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();
        }
        public static IRestResponse<List<MedicineName>> FormMedicineFromIsaRequest()
        {
            return new RestClient("http://localhost:8086").Get<List<MedicineName>>(new RestRequest("/medicineRequested"));
        }
        public String GetMedicineDescriptionFromApi(String medicine)
        {
            return new RestClient(MedicineInformationUrl).Get<String>(new RestRequest("/api/medicineWithQuantity/description/" + medicine)).Data;
        }
        public async Task CreateNewMedicineWithQuantityAsync(String medicine, String description)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CretaeMedicineWithQuantityObject(medicine, description), Formatting.Indented), Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync(MedicineInformationUrl+"/api/medicineWithQuantity", content);
        }

        private static Dictionary<string, object> CretaeMedicineWithQuantityObject(string medicine, string description)
        {
            return new Dictionary<string, object>
            {
                { "name", medicine }, { "quantity",  0}, { "description", description}
            };
        }

        public static List<Message> GetAllMessages()
        {
            return new RestClient(UsersServiceUrl).Get<List<Message>>(new RestRequest("/api/message")).Data;
        }
        public static List<RegistrationInPharmacy> GetPharmacyRegistrations()
        {
            return new RestClient(PharmacyRegistrationUrl).Get<List<RegistrationInPharmacy>>(new RestRequest("/api/registration")).Data;
        }
    }
}
