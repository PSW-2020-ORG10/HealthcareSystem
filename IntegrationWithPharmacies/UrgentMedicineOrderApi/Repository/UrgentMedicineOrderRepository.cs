using System.Collections.Generic;
using System.Linq;
using UrgentMedicineOrderApi.DbContextModel;
using UrgentMedicineOrderApi.Model;

namespace UrgentMedicineOrderApi.Repository
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