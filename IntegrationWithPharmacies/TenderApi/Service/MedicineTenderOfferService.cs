using System.Collections.Generic;
using System.Linq;
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
        public HttpRequests HttpRequests { get; }

        public MedicineTenderOfferService() { }

        public MedicineTenderOfferService(MyDbContext context)
        {
            MedicineTenderOfferRepository = new MedicineTenderOfferRepository(context);
            PharmacyTenderOfferRepository = new PharmacyTenderOfferRepository(context);
            HttpRequests = new HttpRequests();
        }

        public List<MedicineTenderOffer> GetAll()
        {
            return MedicineTenderOfferRepository.GetAll();
        }

        public void CreateAllMedicineTenderOffers(List<MedicineTenderOffer> medicineTenderOffers)
        {
            foreach (MedicineTenderOffer medicineTenderOffer in medicineTenderOffers)
            {
                medicineTenderOffer.PharmacyTenderOfferId = PharmacyTenderOfferRepository.getNextTenderPharmacyOfferId();
                MedicineTenderOfferRepository.Create(medicineTenderOffer);
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
                CheckMedicineInDB(HttpRequests.GetAllMedicinesWithQuantity(), medicineTenderOffer);
            }
        }

        private void CheckMedicineInDB(List<MedicineInformation> medicineInformations, MedicineTenderOffer medicineTenderOffer)
        {
            MedicineInformation medicine = medicineInformations.SingleOrDefault(medicineName => medicineName.MedicineDescription.Name.Equals(medicineTenderOffer.MedicineName));
            if (medicine != null) HttpRequests.UpdateMedicine(medicineTenderOffer, medicine);
            else { _ = HttpRequests.CreateNewMedicineWithQuantityAsync(medicineTenderOffer); }
        }
       
    }
}
