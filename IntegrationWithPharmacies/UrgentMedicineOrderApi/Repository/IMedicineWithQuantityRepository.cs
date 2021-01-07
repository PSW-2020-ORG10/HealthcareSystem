using System.Collections.Generic;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.Repository
{
    public interface IMedicineWithQuantityRepository
    {
        MedicineWithQuantity Create(MedicineWithQuantity medicineWithQuantity);
        List<MedicineWithQuantity> GetAll();
    }
}
