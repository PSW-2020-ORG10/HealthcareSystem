using AppointmentMicroserviceApi.Patient;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Repository
{
    public interface ISurveyRepository
    {
        Survey Add(Survey survey);
        List<Survey> GetAllSurveysForPatientId(int id);
        List<Survey> GetAll();
    }
}
