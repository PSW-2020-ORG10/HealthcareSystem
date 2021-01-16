using MedicineInformationApi.Dto;
using MedicineInformationApi.Model;
using System.Collections.Generic;

namespace MedicineInformationApi.Service
{
    public interface IMedicineInformationService
    {
        MedicineInformation Create(MedicineInformationDto medicineWithQuantityDto);
        List<MedicineInformation> GetAll();
    }
}
