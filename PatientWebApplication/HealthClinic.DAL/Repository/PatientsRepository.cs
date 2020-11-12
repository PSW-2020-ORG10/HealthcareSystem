using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public class PatientsRepository : GenericFileRepository<PatientUser>
    {
        public PatientsRepository(string filePath) : base(filePath) { }

        public PatientsRepository() : base() { }

    }

}

