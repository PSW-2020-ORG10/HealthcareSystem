using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineTenderOfferRepository
    {
        MedicineTenderOffer Create(MedicineTenderOffer medicineTenderOffer);
        List<MedicineTenderOffer> GetAll();
    }
}
