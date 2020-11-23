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
    public class ObservePersonalInformation
    {

        [Fact]
        public void Find_Patient()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService service = new PatientService(CreateStubRepository(), mockVerify.Object);

            PatientUser foundPatient = service.GetOne(1);

            foundPatient.ShouldNotBeNull();
        }

        [Fact]
        public void Find_Not_Patient()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService service = new PatientService(CreateStubRepository(), mockVerify.Object);

            PatientUser foundPatient = service.GetOne(2);

            foundPatient.ShouldBeNull();
        }
        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();

            PatientUser patient = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "11/11/2020", "123", "212313", "Alergija", "Grad", false, "email@gmail.com", "pass", false, "Grad2", "Roditelj", null);

            stubRepository.Setup(m => m.FindOne(1)).Returns(patient);

            return stubRepository.Object;
        }
    }
}
