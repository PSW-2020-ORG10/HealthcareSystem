using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace IntegrationWithPharmacies.FileProtocol
{
    public class HttpService
    {
        public HttpService() { }
        public void UploadReportFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8082/download/file/http"), "POST", complete);
            client.Dispose();
        }
        public void UploadPrescriptionFile(String complete)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadFile(new Uri(@"http://localhost:8082/download/prescription/http"), "POST", complete);
            client.Dispose();
        }
        public void SendUrgentOrder(String order)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadString(new Uri(@"http://localhost:8082/order/urgent/http"), "POST", order);
            client.Dispose();
        }
        public void SendTender(String tender)
        {
            WebClient client = new WebClient();
            client.Credentials = CredentialCache.DefaultCredentials;
            client.UploadString(new Uri(@"http://localhost:8082/order/tender"), "POST", tender);
            client.Dispose();
        }
        public static String FormMedicineAvailabilityRequest(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/medicinePharmacy/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();

        }
        public static string FormMedicineDescriptionRequest(string medicine)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("http://localhost:8082/description/medicine/" + medicine);
            HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
            return new StreamReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("utf-8")).ReadToEnd();
        }
        public static IRestResponse<List<MedicineName>> FormMedicineFromIsaRequest()
        {
            var client = new RestSharp.RestClient("http://localhost:8082");
            var response = client.Get<List<MedicineName>>(new RestRequest("/medicineRequested"));
            //response.Data.ForEach(medicine => Console.WriteLine(medicine.ToString()));
            return response;
        }
    }
}
