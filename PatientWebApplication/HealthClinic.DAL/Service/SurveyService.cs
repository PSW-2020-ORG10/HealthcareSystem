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

        public List<DoctorAppointment> FindAllValidAppointments(List<DoctorAppointment> allValidAppointments)
        {
            List<Survey> allSurveys = GetAllSurveysForPatientId(1);
            List<int> allUnvalidAppointments = FindAllUnvalidAppointments(allSurveys);
            return CheckIfAppointmentsHappened(allValidAppointments.Where(p => !allUnvalidAppointments.Any(p2 => p2 == p.id)).ToList());
        }

        private static List<int> FindAllUnvalidAppointments(List<Survey> allSurveys)
        {
            List<int> allUnvalidAppointments = new List<int>();
            foreach (Survey survey in allSurveys)
            {
                allUnvalidAppointments.Add(survey.appointmentId);
            }

            return allUnvalidAppointments;
        }

        private List<DoctorAppointment> CheckIfAppointmentsHappened(List<DoctorAppointment> allValidAppointments)
        {   
            return allValidAppointments.Where(appointment => UtilityMethods.ParseDateInCorrectFormat(appointment.Date) < DateTime.Now).ToList();
        }
    }
}
