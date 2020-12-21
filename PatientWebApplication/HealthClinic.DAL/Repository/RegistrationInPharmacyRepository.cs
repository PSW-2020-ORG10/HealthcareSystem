using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class RegistrationInPharmacyRepository : IRegistrationInPharmacyRepository 
    {
        private MyDbContext DbContext;

        public RegistrationInPharmacyRepository(MyDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public RegistrationInPharmacy Create(RegistrationInPharmacy registration)
        {
            DbContext.Registrations.Add(registration);
            DbContext.SaveChanges();
            return registration;
        }
        public List<RegistrationInPharmacy> GetAll()
        {
            return DbContext.Registrations.ToList();
        }
       
        public RegistrationInPharmacy getPharmacyApiKey(String apiKey)
        {
            return DbContext.Registrations.ToList().SingleOrDefault(registration => registration.ApiKey == apiKey);
        }
        public Boolean Remove(String apiKey)
        {
            try {
                DbContext.Registrations.Remove(DbContext.Registrations.ToList().SingleOrDefault(registration => registration.ApiKey == apiKey));
                return true;
            }
            catch {return false; }
        }


    }
}
