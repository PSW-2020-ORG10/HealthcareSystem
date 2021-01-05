using HealthClinic.CL.Adapters;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using HealthClinic.CL.Repository;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Service
{
    public class MedicineTenderOfferService : IMedicineTenderOfferService
    {
        public MedicineTenderOfferRepository MedicineTenderOfferRepository { get; }
        public PharmacyTenderOfferRepository PharmacyTenderOfferRepository { get; }
        public MedicineTenderOfferService() { }

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
    }
}
