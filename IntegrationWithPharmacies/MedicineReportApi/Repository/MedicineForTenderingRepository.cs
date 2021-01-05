using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MedicineReportApi.Repository
{
    public class MedicineForTenderingRepository : IMedicineForTenderingRepository
    {
        private MyDbContext DbContext;
        public MedicineForTenderingRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
  
        public List<MedicineForTendering> GetAll()
        {
            return DbContext.MedicineForTendering.ToList();
        }
    }
}
