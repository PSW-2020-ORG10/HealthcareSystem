using MedicineInformationApi.Model;
using System.Collections.Generic;

namespace MedicineInformationApi.Repository
{
    public interface IMedicineInformationRepository
    {
        MedicineInformation Create(MedicineInformation medicineWithQuantity);
        List<MedicineInformation> GetAll();
    }
}
