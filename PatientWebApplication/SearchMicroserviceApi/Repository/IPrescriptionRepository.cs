using SearchMicroserviceApi.Model;
using System.Collections.Generic;

namespace SearchMicroserviceApi.Repository
{
    public interface IPrescriptionRepository
    {
        List<Prescription> GetAll();
        List<Prescription> GetPrescriptionsForPatient(int idPatient);
        Prescription GetPrescriptionsForAppointment(int idAppointment);
    }
}