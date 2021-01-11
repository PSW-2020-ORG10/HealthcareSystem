using MedicineInformationApi.Dto;
using MedicineInformationApi.Model;
using System.Collections.Generic;

namespace MedicineInformationApi.Service
{
    public interface IMedicineWithQuantityService
    {
        MedicineWithQuantity Create(MedicineWithQuantityDto medicineWithQuantityDto);
        List<MedicineWithQuantity> GetAll();
    }
}
