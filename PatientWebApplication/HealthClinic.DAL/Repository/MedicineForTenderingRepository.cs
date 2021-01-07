using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
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
            //DbContext.MedicineForTendering.Add(medicine);
            DbContext.SaveChanges();
            return medicine;
        }

        public List<MedicineForTendering> GetAll()
        {
            return null;
           // return DbContext.MedicineForTendering.ToList();
        }
    }
}
