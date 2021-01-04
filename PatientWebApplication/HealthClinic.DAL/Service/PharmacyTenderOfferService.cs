using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Service
{
    public class PharmacyTenderOfferService : IPharmacyTenderOfferService
    {
        public PharmacyTenderOfferRepository PharmacyTenderOfferRepository { get; }
        private IPharmacyTenderOfferRepository IPharmacyTenderOfferRepository { get; set; }
        private MedicineTenderOfferService MedicineTenderOfferService { get;}
        public PharmacyTenderOfferService() { }

        public PharmacyTenderOfferService(MyDbContext context)
        {
            PharmacyTenderOfferRepository = new PharmacyTenderOfferRepository(context);
            MedicineTenderOfferService = new MedicineTenderOfferService(context);
        }
        public PharmacyTenderOfferService(IPharmacyTenderOfferRepository pharmacyTenderOfferRepository)
        {
            IPharmacyTenderOfferRepository = pharmacyTenderOfferRepository;
        }
        public PharmacyTenderOffer Create(PharmacyTenderOfferDto dto)
        {
            return PharmacyTenderOfferRepository.Create(PharmacyTenderOfferAdapter.PharmacyTenderOfferDtoToPharmacyTenderOffer(dto));
        }
        
        public List<PharmacyTenderOffer> GetAll()
        {
            return PharmacyTenderOfferRepository.GetAll();
        }

        public PharmacyTenderOffer CreateFromTenderOrder(TenderOrder tenderOrder)
        {
            return PharmacyTenderOfferRepository.Create(PharmacyTenderOfferAdapter.PharmacyTenderOrdedDtoToPharmacyTenderOffer(tenderOrder));
        }

        public List<TenderOrder> GetAllPharmacyOffersForTender(int id)
        {
            List<TenderOrder> tenders = new List<TenderOrder>();
            foreach (PharmacyTenderOffer pharmacyTenderOffer in GetAll().Where(offer => offer.TenderId == id).ToList())
            {
                GetOnePharmyOfferForTender(tenders, pharmacyTenderOffer);
            }
            return tenders;
        }

        private void GetOnePharmyOfferForTender(List<TenderOrder> tenders, PharmacyTenderOffer pharmacyTenderOffer)
        {
            List<MedicineTenderOffer> medicineTenderOffers = MedicineTenderOfferService.GetAll().Where(offer => offer.PharmacyTenderOfferId == pharmacyTenderOffer.id).ToList();
            tenders.Add(new TenderOrder(medicineTenderOffers, pharmacyTenderOffer.TenderId, pharmacyTenderOffer.id, pharmacyTenderOffer.PharmacyApi));
        }

        public TenderOrder GetPharmacyOffer(int offerId, int tenderId)
        {
            return GetAllPharmacyOffersForTender(tenderId).SingleOrDefault(offer => offer.PharmacyTenderOfferId == offerId);
        }
    }
}
