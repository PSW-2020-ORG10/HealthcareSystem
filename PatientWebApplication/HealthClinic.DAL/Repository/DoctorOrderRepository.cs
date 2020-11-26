
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class DoctorOrderRepository
    {
        private readonly MyDbContext dbContext;
    
        public DoctorOrderRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public DoctorsOrder Add(DoctorsOrder order)
        {
            dbContext.DoctorsOrders.Add(order);
            dbContext.SaveChanges();
            return order;
        }

        public List<DoctorsOrder> GetAll()
        {
            return dbContext.DoctorsOrders.ToList();
        }



    }
}
