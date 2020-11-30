using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class DoctorOrderRepository
    {
        private readonly MyDbContext DbContext;
    
        public DoctorOrderRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public DoctorsOrder Add(DoctorsOrder order)
        {
            DbContext.DoctorsOrders.Add(order);
            DbContext.SaveChanges();
            return order;
        }

        public List<DoctorsOrder> GetAll()
        {
            return DbContext.DoctorsOrders.ToList();
        }
    }
}
