using AppointmentMicroserviceApi.Patient;
using HealthClinic.CL.Dtos;
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
