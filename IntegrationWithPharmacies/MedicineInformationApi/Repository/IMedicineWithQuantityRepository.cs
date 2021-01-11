using MedicineInformationApi.Model;
using System.Collections.Generic;

namespace MedicineInformationApi.Repository
{
    public interface IMedicineWithQuantityRepository
    {
        MedicineWithQuantity Create(MedicineWithQuantity medicineWithQuantity);
        List<MedicineWithQuantity> GetAll();
    }
}
