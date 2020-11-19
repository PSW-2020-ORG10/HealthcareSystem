using HealthClinic.CL.DbContextModel;
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class PatientsRepository 
    {
        private readonly MyDbContext dbContext;
        public PatientsRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public PatientUser Add(PatientUser patient)
        {
            dbContext.Patients.Add(patient);
            dbContext.SaveChanges();
            return patient;
        }

    }

}

