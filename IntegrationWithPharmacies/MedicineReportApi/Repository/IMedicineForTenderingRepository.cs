using MedicineReportApi.Model;
using System.Collections.Generic;

namespace MedicineReportApi.Repository
{
    public interface IMedicineForTenderingRepository
    {
        List<MedicineForTendering> GetAll();
    }
}
