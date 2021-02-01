using AppointmentMicroserviceApi.Dtos;
using AppointmentMicroserviceApi.Patient;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Service
{
    public interface ISurveyService
    {
        Survey Create(SurveyDto surveyDto);
        List<Survey> GetAllSurveysForPatientId(int id);
        List<Survey> GetAll();
        SurveyAverageDto GetAllAverageRates();
        List<MicroserviceSurveyDoctorAverageDto> GetAllDoctorAverageRates();

    }
}
