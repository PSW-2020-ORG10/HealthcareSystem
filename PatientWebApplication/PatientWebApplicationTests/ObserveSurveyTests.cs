using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class ObserveSurveyTests
    {
        [Fact]
        public void Get_Rates_Successfuly()
        {
            SurveyService service = new SurveyService(CreateStubRepository());
            SurveyAverageDto foundSurvey = service.GetAllAverageRates();
            foundSurvey.ShouldNotBeNull();
        }

        [Fact]
        public void Get_Doctors_Rates_Successfuly()
        {
            SurveyService service = new SurveyService(CreateStubRepository());
            List<SurveyDoctorAverageDto> foundSurveys = service.GetAllDoctorAverageRates();           
            foundSurveys.ShouldNotBeNull();
        }

        private static ISurveyRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();

            var surveys = new List<Survey>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "04/02/2019", patient1, doctor1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "11/01/2016", patient1, doctor2, new List<Referral>(), "1");


            Survey survey1 = new Survey(1, 1, 4, appointment1, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5);
            Survey survey2 = new Survey(1, 1, 5, appointment2, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5);


            surveys.Add(survey1);
            surveys.Add(survey2);

            stubRepository.Setup(m => m.GetAll()).Returns(surveys);

            return stubRepository.Object;
        }
    }
}
