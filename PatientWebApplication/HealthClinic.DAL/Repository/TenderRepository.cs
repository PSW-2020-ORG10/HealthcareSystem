using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Orders;

namespace HealthClinic.CL.Repository
{
    public class TenderRepository : ITenderRepository
    {
        private MyDbContext DbContext;
        public TenderRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public Tender Create(Tender tender)
        {
            DbContext.Tender.Add(tender);
            DbContext.SaveChanges();
            return tender;
        }

        public List<Tender> GetAll()
        {
            return DbContext.Tender.ToList();
        }
    }
}
