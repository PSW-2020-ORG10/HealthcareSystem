using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IPatientsRepository
    {
        PatientUser Add(PatientUser patient);
        List<PatientUser> GetAll();
    }
}