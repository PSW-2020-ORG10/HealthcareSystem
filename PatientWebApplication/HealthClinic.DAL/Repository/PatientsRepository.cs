using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace HealthClinic.CL.Repository
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly MyDbContext dbContext;
        public PatientsRepository()
        {
            var options = new DbContextOptionsBuilder<MyDbContext>().UseMySql("Server=localhost;port=3306;Database=MYSQLHealtcareDB;user=root;password=root").UseLazyLoadingProxies().Options;
            this.dbContext = new MyDbContext(options);
        }

        public PatientUser Add(PatientUser patient)
        {
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
            return patient;
        }

        public PatientUser Find(int id)
        {
            return dbContext.Patients.SingleOrDefault(patient => patient.id == id);
        }

        public PatientUser Validate(PatientUser patient)
        {
            patient.isVerified = true;
            dbContext.SaveChanges();
            return patient;
        }
        
    }

}

