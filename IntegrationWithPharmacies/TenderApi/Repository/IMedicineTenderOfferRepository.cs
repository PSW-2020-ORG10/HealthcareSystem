using System.Collections.Generic;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public interface IMedicineTenderOfferRepository
    {
        MedicineTenderOffer Create(MedicineTenderOffer medicineTenderOffer);
        List<MedicineTenderOffer> GetAll();
    }
}
