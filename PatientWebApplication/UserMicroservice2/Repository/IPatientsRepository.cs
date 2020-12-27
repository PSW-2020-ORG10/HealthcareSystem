using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace UserMicroservice.Repository
{
    public interface IPatientsRepository
    {
        PatientUser Add(PatientUser patient);
        PatientUser FindOne(int id);
        PatientUser Validate(PatientUser patient);
        List<PatientUser> GetAll();
        PatientUser BlockPatient(PatientUser patient);
    }
}