using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;


namespace HealthClinic.CL.Repository
{
    public interface IMedicineForOrderingRepository
    {
        MedicineForOrdering Create(MedicineForOrdering medicine);
        List<MedicineForOrdering> GetAll();
    }
}
