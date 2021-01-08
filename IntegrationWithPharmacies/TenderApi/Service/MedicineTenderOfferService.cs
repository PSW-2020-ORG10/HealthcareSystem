using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TenderApi.Adapter;
using TenderApi.DbContextModel;
using TenderApi.Dto;
using TenderApi.Model;
using TenderApi.Repository;

namespace TenderApi.Service
{
    public class MedicineTenderOfferService
    {
        public MedicineTenderOfferRepository MedicineTenderOfferRepository { get; }
        public PharmacyTenderOfferRepository PharmacyTenderOfferRepository { get; }
        public MedicineTenderOfferService() { }

        private static readonly string medicineInformationUrl = Startup.Configuration["MedicineInformationApi"];

        public MedicineTenderOfferService(MyDbContext context)
        {
            MedicineTenderOfferRepository = new MedicineTenderOfferRepository(context);
            PharmacyTenderOfferRepository = new PharmacyTenderOfferRepository(context);
        }

        public List<MedicineTenderOffer> GetAll()
        {
            return MedicineTenderOfferRepository.GetAll();
        }

        public MedicineTenderOffer Create(MedicineTenderOfferDto medicineTenderOfferDto)
        {
            return MedicineTenderOfferRepository.Create(MedicineTenderOfferAdapter.MedicineTenderOfferDtoToMedicineTenderOffer(medicineTenderOfferDto));
        }

        public void CreateAllMedicineTenderOffers(List<MedicineTenderOffer> medicineTenderOffers)
        {
            foreach (MedicineTenderOffer medicineTenderOffer in medicineTenderOffers)
            {
                Create(MedicineTenderOfferAdapter.MedicineTenderOfferToMedicineTenderOfferDto(new MedicineTenderOffer(medicineTenderOffer.MedicineName, medicineTenderOffer.Quantity, medicineTenderOffer.AvailableQuantity, medicineTenderOffer.Price, PharmacyTenderOfferRepository.getNextTenderPharmacyOfferId())));
            }
        }
        public List<MedicineTenderOffer> GetMedicineOffersByPharmacyOfferId(int pahrmacyTenderOfferId)
        {
            return GetAll().Where(offer => offer.PharmacyTenderOfferId == pahrmacyTenderOfferId).ToList();
        }
        public void UpdateMedicineQuantity(int offerId)
        {
            foreach (MedicineTenderOffer medicineTenderOffer in GetMedicineOffersByPharmacyOfferId(offerId))
            {
                CheckMedicineInDB(GetAllMedicinesWithQuantity(), medicineTenderOffer);
            }
        }

        public static List<MedicineWithQuantity> GetAllMedicinesWithQuantity()
        {
            //var responseString = await client.GetAsync($"{medicineInformationUrl}api/medicineWithQuantity");
            //return await responseString.Content.ReadAsAsync<List<MedicineWithQuantity>>();

            //var medicines = await client.GetAsync($"{medicineInformationUrl}api/medicineWithQuantity");
            var client = new RestSharp.RestClient(medicineInformationUrl);
            var medicines = client.Get<List<MedicineWithQuantity>>(new RestRequest("/api/medicineWithQuantity"));

            return medicines.Data;
        }

        private void CheckMedicineInDB(List<MedicineWithQuantity> medicineWithQuantities, MedicineTenderOffer medicineTenderOffer)
        {
            MedicineWithQuantity medicine = medicineWithQuantities.SingleOrDefault(medicineName => medicineName.Name == medicineTenderOffer.MedicineName);
            if (medicine != null) UpdateMedicine(medicineTenderOffer, medicine);
            else { _ = CreateNewMedicineWithQuantityAsync(medicineTenderOffer); }
        }
        private async Task CreateNewMedicineWithQuantityAsync(MedicineTenderOffer medicineTenderOffer)
        {
            var values = new Dictionary<string, object>
            {
                {"name", medicineTenderOffer.MedicineName }, {"quantity",  medicineTenderOffer.AvailableQuantity }, {"description", ""}
            };
            var content = new StringContent(JsonConvert.SerializeObject(values, Formatting.Indented), Encoding.UTF8, "application/json");
            using HttpClient client = new HttpClient();
            await client.PostAsync($"{medicineInformationUrl}api/medicineWithQuantity", content);
        }
        private void UpdateMedicine(MedicineTenderOffer medicineTenderOffer, MedicineWithQuantity medicine)
        {
            var client = new RestSharp.RestClient(medicineInformationUrl);
            client.Get<List<MedicineWithQuantity>>(new RestRequest("/api/medicineWithQuantity/"+medicine.Id+"/"+ medicineTenderOffer.AvailableQuantity));
        }
    }
}
