using System.Collections.Generic;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public interface IMedicineForTenderingRepository
    {
        MedicineForTendering Create(MedicineForTendering medicine);
        List<MedicineForTendering> GetAll();
    }
}
