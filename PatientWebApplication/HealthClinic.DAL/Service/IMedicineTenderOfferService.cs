using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
    public interface IMedicineTenderOfferService
    {
        MedicineTenderOffer Create(MedicineTenderOfferDto medicineTenderOfferDto);
        List<MedicineTenderOffer> GetAll();
    }
}
