﻿using Moq;
using Shouldly;
using System.Collections.Generic;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;
using Xunit;

namespace PatientWebApplicationTests
{
    public class PatientRegistrationTests 
    {
        [Fact]
        public void Create_Registration_Successfuly()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService service = new PatientService(CreateStubRepository(), mockVerify.Object);

            PatientUser patient =  service.Create(new PatientDto("Pera2", "Peric", "Male", "1234", "11/11/2000", "1231412", "21312312", "Alergija", "Grad", "email@gmail.com", "pass", false, "Grad2", "Roditelj", "", ""));
            patient.ShouldNotBeNull();

        }    


        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();
            PatientUser patient = new PatientUser(4, "Pera2", "Peric", "Male", "1234", "11/11/2020", "123", "212313", "Alergija", "Grad", false, "email@gmail.com", "pass", false, "Grad2", "Roditelj", null);
            
            var patients = new List<PatientUser>();
          
            stubRepository.Setup(m => m.Add(It.IsAny<PatientUser>())).Returns(patient);

            return stubRepository.Object;

        }
    }
}
