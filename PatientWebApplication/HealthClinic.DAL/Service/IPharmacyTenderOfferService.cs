using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public interface IPharmacyTenderOfferService
    {
        PharmacyTenderOffer Create(PharmacyTenderOfferDto dto);
        List<PharmacyTenderOffer> GetAll();
    }
}
