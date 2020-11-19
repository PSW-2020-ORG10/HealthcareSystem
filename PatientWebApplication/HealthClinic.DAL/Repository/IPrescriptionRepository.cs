using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Repository
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAll();
        List<Prescription> GetPrescriptionsForPatient(int idPatient);
    }
}