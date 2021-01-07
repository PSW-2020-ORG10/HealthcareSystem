using UrgentMedicineOrderApi.Dto;
using UrgentMedicineOrderApi.Model;
using System.Collections.Generic;

namespace UrgentMedicineOrderApi.Service
{
   public interface IMedicineWithQuantityService
    {
        MedicineWithQuantity Create(MedicineWithQuantityDto medicineWithQuantityDto);
        List<MedicineWithQuantity> GetAll();
    }
}
