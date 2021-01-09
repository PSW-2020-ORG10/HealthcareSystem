using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TenderApi.Model;

namespace TenderApi.Service
{
    public class HttpRequests
    {
        private static readonly string medicineInformationUrl = Startup.Configuration["MedicineInformationApi"];

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
                {"name", medicineTenderOffer.MedicineName }, {"quantity",  medicineTenderOffer.AvailableQuantity }, {"description", ""}
            };
        }

        public static List<MedicineWithQuantity> GetAllMedicinesWithQuantity()
        {
            return new RestClient(medicineInformationUrl).Get<List<MedicineWithQuantity>>(new RestRequest("api/medicineWithQuantity")).Data;
        }
        public void UpdateMedicine(MedicineTenderOffer medicineTenderOffer, MedicineWithQuantity medicine)
        {
            new RestClient(medicineInformationUrl).Get<List<MedicineWithQuantity>>(new RestRequest("api/medicineWithQuantity/" + medicine.Id + "/" + medicineTenderOffer.AvailableQuantity));
        }
    }
}
