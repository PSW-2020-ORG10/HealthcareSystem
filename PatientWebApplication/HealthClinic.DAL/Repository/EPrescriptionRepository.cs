using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class EPrescriptionRepository : IEPrescriptionRepository
    {
        private MyDbContext DbContext;
        public EPrescriptionRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public EPrescription Create(EPrescription prescription)
        {
            DbContext.EPrescriptions.Add(prescription);
            DbContext.SaveChanges();
            return prescription;
        }

        public List<EPrescription> GetAll()
        {
            return DbContext.EPrescriptions.ToList();
        }
    }
}
