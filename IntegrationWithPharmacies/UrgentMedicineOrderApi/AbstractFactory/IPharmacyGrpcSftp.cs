
using System;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public interface IPharmacyGrpcSftp : IPharmacy
    {
        String FormUrgentOrderGrpc(String medicine);
    }
}
