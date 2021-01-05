using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface IPharmacyTenderOfferRepository
    {
        PharmacyTenderOffer Create(PharmacyTenderOffer pharmacyTenderOffer);
        List<PharmacyTenderOffer> GetAll();
    }
}
