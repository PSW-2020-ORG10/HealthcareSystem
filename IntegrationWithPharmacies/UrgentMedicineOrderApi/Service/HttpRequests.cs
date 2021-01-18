using RestSharp;
using System;
using System.IO;
using System.Net;

namespace UrgentMedicineOrderApi.Service
{
    public class HttpRequests
    {
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
    }
}
