using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Repository
{
    public interface IPatientsRepository
    {
        PatientUser Add(PatientUser patient);
        PatientUser Find(int id);
        PatientUser Validate(PatientUser patient);
    }
}