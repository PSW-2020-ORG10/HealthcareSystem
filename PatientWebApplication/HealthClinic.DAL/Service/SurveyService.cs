using HealthClinic.CL.Adapters;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using HealthClinic.CL.Utility;
using System.Text;

namespace HealthClinic.CL.Service
{
    public class SurveyService : ISurveyService
    {
        private ISurveyRepository SurveyRepository { get; set; }

        public SurveyService(ISurveyRepository surveyRepository)
        {
            SurveyRepository = surveyRepository;           
        }

        public Survey Create(SurveyDto surveyDto)
        {                   
            return SurveyRepository.Add(SurveyAdapter.SurveyDtoToSurvey(surveyDto));
        }

        public List<Survey> GetAllSurveysForPatientId(int id)
        {
            return SurveyRepository.GetAllSurveysForPatientId(id);
        }
    }
}
