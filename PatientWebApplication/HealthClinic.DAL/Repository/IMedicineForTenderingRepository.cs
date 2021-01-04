using System.Collections.Generic;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public interface IMedicineForTenderingRepository
    {
        MedicineForTendering Create(MedicineForTendering medicine);
        List<MedicineForTendering> GetAll();
    }
}
