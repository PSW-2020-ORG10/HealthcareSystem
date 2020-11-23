using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Pharmacy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public class RegistrationInPharmacyRepository : IRegistrationInPharmacyRepository 
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
       
        public RegistrationInPharmacy getPharmacyApiKey(String apiKey)
        {
            Console.WriteLine(dbContext.Registrations.ToList().SingleOrDefault(registration => registration.apiKey == apiKey));
            return dbContext.Registrations.ToList().SingleOrDefault(registration => registration.apiKey == apiKey);
        }

        
    }
}
