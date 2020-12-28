using System.Collections.Generic;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineForTenderingRepository
    {
        MedicineForTendering Create(MedicineForTendering order);
        List<MedicineForTendering> GetAll();
    }
}
