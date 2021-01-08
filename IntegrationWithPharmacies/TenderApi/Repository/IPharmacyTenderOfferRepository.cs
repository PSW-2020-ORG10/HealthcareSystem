using System.Collections.Generic;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public interface IPharmacyTenderOfferRepository
    {
        PharmacyTenderOffer Create(PharmacyTenderOffer pharmacyTenderOffer);
        List<PharmacyTenderOffer> GetAll();
    }
}
