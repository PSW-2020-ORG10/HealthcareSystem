using HealthClinic.CL.Dtos;
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
            PatientService patientService = new PatientService(CreateStubRepository(), mockVerify.Object, new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository())));

            PatientUser patient1 = patientService.Create(new PatientDto("Pera2", "Peric", "Male", "1234", "11/11/2000", "1231412", "21312312", "Alergija", "Grad", "email@gmail.com", "pass", false, "Grad2", "Roditelj", "", ""));

            mockVerify.Verify(v => v.SendVerificationMail(new MailAddress(patient1.email), patient1.id), Times.Once);
        }

        [Fact]
        public void Validates_registered_patient()
        {
            var mockVerify = new Mock<IEmailVerificationService>();
            PatientService patientService = new PatientService(CreateStubRepository(), mockVerify.Object, new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository())));

            PatientUser patient = patientService.Validate(1);

            Assert.True(patient.isVerified);
        }

        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();

            PatientUser patient1 = new PatientUser(4, "Pera2", "Peric", "Male", "1234", "11/11/2020", "123", "212313", "Alergija", "Grad", false, "email@gmail.com", "pass", false, "Grad2", "Roditelj", null);

            stubRepository.Setup(e => e.Find(It.IsAny<int>())).Returns(patient1);
            stubRepository.Setup(e => e.Validate(patient1)).Returns<PatientUser>(patient => new PatientUser(patient1));
            stubRepository.Setup(m => m.Add(It.IsAny<PatientUser>())).Returns(patient1);

            return stubRepository.Object;
        }

    }
}
