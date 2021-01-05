using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;

namespace HealthClinic.CL.Service
{
   public interface IMedicineWithQuantityService
    {
        MedicineWithQuantity Create(MedicineWithQuantityDto medicineWithQuantityDto);
        List<MedicineWithQuantity> GetAll();
    }
}
