

using System;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public interface IPharmacyHttp : IPharmacy
    {
        String FormUrgentOrderHttp(string medicine);
    }
}
