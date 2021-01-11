using System.Collections.Generic;
using System.Linq;
using TenderApi.DbContextModel;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public class PharmacyTenderOfferRepository : IPharmacyTenderOfferRepository
    {
        private MyDbContext DbContext;
        public PharmacyTenderOfferRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public PharmacyTenderOffer Create(PharmacyTenderOffer pharmacyTenderOffer)
        {

            DbContext.PharmacyTenderOffers.Add(pharmacyTenderOffer);
            DbContext.SaveChanges();
            return pharmacyTenderOffer;
        }

        public List<PharmacyTenderOffer> GetAll()
        {
            return DbContext.PharmacyTenderOffers.ToList();
        }
        public int getNextTenderPharmacyOfferId()
        {
            return GetAll().Max(offer => offer.Id);
        }
    }
}
