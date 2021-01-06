using System.Collections.Generic;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Repository
{
    public interface IPatientsRepository
    {
        PatientUser Add(PatientUser patient);
        PatientUser FindOne(int id);
        PatientUser Validate(PatientUser patient);
        List<PatientUser> GetAll();
        PatientUser BlockPatient(PatientUser patient);
        PatientUser GetByEmail(string email);
        PatientUser GetByLoginInfo(UserModel login);
    }
}