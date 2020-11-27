using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Service
{
    public interface ISurveyService
    {
        Survey Create(SurveyDto surveyDto);
        List<Survey> GetAllSurveysForPatientId(int id);            
    }
}
