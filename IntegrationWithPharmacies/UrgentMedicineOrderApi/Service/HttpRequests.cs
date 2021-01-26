using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.Service
{
    public class HttpRequests
    {
        private static readonly string pharmacyRegistrationUrl = Startup.Configuration["PharmacyRegistrationApi"];
        private static readonly string medicineInformationUrl = Startup.Configuration["MedicineInformationApi"];

        public HttpRequests() { }
       
        public void SendUrgentOrder(String order)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadString(new Uri(@"http://localhost:8086/order/urgent/http"), "POST", order);
            client.Dispose();
        }
       
        public static String FormMedicineAvailabilityRequest(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8086/medicinePharmacy/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();
        }
        public static String FormMedicineAvailabilityRequest2(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/medicinePharmacy/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();
        }

        public static List<RegistrationInPharmacy> GetRegistrationsInPharmaciesAll()
        {
            return new RestClient(pharmacyRegistrationUrl).Get<List<RegistrationInPharmacy>>(new RestRequest("api/registration")).Data;
        }

        public static void UpdateMedicineQuantity(string medicine)
        {
            new RestClient($"{medicineInformationUrl}").Put(new RestRequest("api/medicineWithQuantity/" + medicine));
        }

    }
}
