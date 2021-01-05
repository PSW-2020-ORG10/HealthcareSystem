using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineWithQuantityRepository
    {
        MedicineWithQuantity Create(MedicineWithQuantity medicineWithQuantity);
        List<MedicineWithQuantity> GetAll();
    }
}
