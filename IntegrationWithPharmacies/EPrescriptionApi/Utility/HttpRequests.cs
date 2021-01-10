using EPrescriptionApi.Model;
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
        private static readonly string medicineInformationUrl = Startup.Configuration["MedicineInformationApi"];

        public HttpRequests() { }
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
            return new RestClient("http://localhost:8082").Get<List<MedicineName>>(new RestRequest("/medicineRequested"));
        }
        public String GetMedicineDescriptionFromApi(String medicine)
        {
            return new RestClient(medicineInformationUrl).Get<String>(new RestRequest("/api/medicineWithQuantity/description/" + medicine)).Data;
        }
        public async Task CreateNewMedicineWithQuantityAsync(String medicine, String description)
        {
            var content = new StringContent(JsonConvert.SerializeObject(CretaeMedicineWithQuantityObject(medicine, description), Formatting.Indented), Encoding.UTF8, "application/json");
            await new HttpClient().PostAsync(medicineInformationUrl+"/api/medicineWithQuantity", content);
        }

        private static Dictionary<string, object> CretaeMedicineWithQuantityObject(string medicine, string description)
        {
            return new Dictionary<string, object>
            {
                { "name", medicine }, { "quantity",  0}, { "description", description}
            };
        }
    }
}
