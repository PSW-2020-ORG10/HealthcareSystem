using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Repository
{
    public interface ISurveyRepository
    {
        Survey Add(Survey survey);
        List<Survey> GetAllSurveysForPatientId(int id);
    }
}
