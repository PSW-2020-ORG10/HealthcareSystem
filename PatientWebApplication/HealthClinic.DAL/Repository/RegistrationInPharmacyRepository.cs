using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class RegistrationInPharmacyRepository
    {
        private MyDbContext dbContext;

        public RegistrationInPharmacyRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public RegistrationInPharmacy Create(RegistrationInPharmacy registration)
        {
            dbContext.Registrations.Add(registration);
            dbContext.SaveChanges();
            return registration;
        }
        public List<RegistrationInPharmacy> GetAll()
        {
            return dbContext.Registrations.ToList();
        }
        public RegistrationInPharmacy getApiKey(int pharmacyId)
        {
            return dbContext.Registrations.SingleOrDefault(registration => registration.pharmacyId == pharmacyId);
        }
        public RegistrationInPharmacy getPharmacyId(String apiKey)
        {
            return dbContext.Registrations.SingleOrDefault(registration => registration.apiKey == apiKey);
        }
    }
}
