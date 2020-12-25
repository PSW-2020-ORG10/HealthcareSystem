using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
   public class UrgentMedicineOrderRepository : IUrgentMedicineOrderRepository
    {
        private MyDbContext DbContext;
        public UrgentMedicineOrderRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public UrgentMedicineOrderRepository() { }
        public UrgentMedicineOrder Create(UrgentMedicineOrder order)
        {
            DbContext.UrgentMedicineOrder.Add(order);
            DbContext.SaveChanges();
            return order;
        }

        public List<UrgentMedicineOrder> GetAll()
        {
            return DbContext.UrgentMedicineOrder.ToList();
        }
    }
}