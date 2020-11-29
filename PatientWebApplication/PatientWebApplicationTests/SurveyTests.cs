using HealthClinic.CL.Dtos;
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
    public class SurveyTests
    {

        [Fact]
        public void Create_Survey_Successfuly()
        { 
            SurveyService service = new SurveyService(CreateStubRepository());
            Survey survay = service.Create(new SurveyDto(1, 1, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5)); 
            survay.ShouldNotBeNull();
        }


        private static ISurveyRepository CreateStubRepository()
        {
            var stubRepository = new Mock<ISurveyRepository>();

            Survey survay = new Survey(1, 1, 4, 5, 4, 5, 4, 5, 4, 5, 5, 5, 5, 4, 3, 3, 2, 2, 5);
            var surveys = new List<Survey>();

            stubRepository.Setup(m => m.Add(It.IsAny<Survey>())).Returns(survay);

            return stubRepository.Object;

        }
    }
}
