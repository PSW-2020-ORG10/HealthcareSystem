using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class EmailVerificationTest
    {
        [Fact]
        public void Sends_verification_email()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService patientService = new PatientService(CreateStubRepository(), mockVerify.Object);

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "nekiTamo@gmail.com", "pass", false, "Grad2", "Roditelj");

            patientService.Create(patient1);

            mockVerify.Verify(v => v.SendVerificationMail(new MailAddress(patient1.email), patient1.id), Times.Once);
        }

        [Fact]
        public void Validates_registered_patient()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService patientService = new PatientService(CreateStubRepository(), mockVerify.Object);

            PatientUser patient = patientService.Validate(1);

            Assert.True(patient.isVerified);
        }

        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "1234", "2/2/2020", "123", "1234", "Alergija", "Grad", false, "nekiTamo@gmail.com", "pass", false, "Grad2", "Roditelj");

            stubRepository.Setup(e => e.Find(patient1.id)).Returns(patient1);
            stubRepository.Setup(e => e.Validate(patient1)).Returns<PatientUser>(patient => new PatientUser(patient1));

            return stubRepository.Object;
        }

    }
}
