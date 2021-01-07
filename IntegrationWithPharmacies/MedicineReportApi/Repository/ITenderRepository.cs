using MedicineReportApi.Model;
using System.Collections.Generic;

namespace MedicineReportApi.Repository
{
    public interface ITenderRepository
    {
        List<Tender> GetAll();
    }
}
