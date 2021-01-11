using System.Collections.Generic;
using System.Linq;
using TenderApi.DbContextModel;
using TenderApi.Model;

namespace TenderApi.Repository
{
    public class MedicineForTenderingRepository : IMedicineForTenderingRepository
    {
        private MyDbContext DbContext;
        public MedicineForTenderingRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public MedicineForTendering Create(MedicineForTendering medicine)
        {
            DbContext.MedicineForTendering.Add(medicine);
            DbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineForTendering> GetAll()
        {
            return DbContext.MedicineForTendering.ToList();
        }
    }
}
