using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class MedicineTenderOfferRepository : IMedicineTenderOfferRepository
    {
        private MyDbContext DbContext;
        public MedicineTenderOfferRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineTenderOffer Create(MedicineTenderOffer medicineTenderOffer)
        {
            DbContext.MedicineTenderOffers.Add(medicineTenderOffer);
            DbContext.SaveChanges();
            return medicineTenderOffer;
        }

        public List<MedicineTenderOffer> GetAll()
        {
            return DbContext.MedicineTenderOffers.ToList();
        }
    }
}
