using Microsoft.AspNetCore.Mvc;
using System;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.AbstractFactory
{
    public interface IPharmacy
    {
        String CreateUrgentOrder(String medicine);
    }
}
