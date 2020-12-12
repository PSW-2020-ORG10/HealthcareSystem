using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IPatientsRepository
    {
        PatientUser Add(PatientUser patient);
        PatientUser Find(int id);
        PatientUser Validate(PatientUser patient);
        List<PatientUser> GetAll();
        PatientUser FindOne(int id);
        PatientUser BlockPatient(PatientUser patient);
    }
}