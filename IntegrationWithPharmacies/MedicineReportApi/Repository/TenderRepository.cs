using MedicineReportApi.DbContextModel;
using MedicineReportApi.Model;
using System.Collections.Generic;
using System.Linq;

namespace MedicineReportApi.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private MyDbContext DbContext;
        public TenderRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<Tender> GetAll()
        {
            return DbContext.Tender.ToList();
        }
    }
}
