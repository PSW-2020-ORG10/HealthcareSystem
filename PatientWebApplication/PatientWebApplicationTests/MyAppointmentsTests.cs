using AppointmentMicroserviceApi.Doctor;
using AppointmentMicroserviceApi.Patient;
using AppointmentMicroserviceApi.Repository;
using AppointmentMicroserviceApi.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using UserMicroserviceApi.Model;
using Xunit;

namespace PatientWebApplicationTests
{
    public class MyAppointmentsTests
    {

        [Fact]
        public void Get_Appointments_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(1), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatient(1);
            foundAppointments.ShouldNotBeNull();
        }

        [Fact]
        public void Get_Appointments_Unsuccessfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(2), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatient(2);
            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForNextTwoDays(), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Unsuccessfuly_Because_They_Happend_Before()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(1), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldBeEmpty();
        }


        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Unsuccessfuly_Because_They_Happend_After()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(1), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Future_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(1), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInFuture(1);
            foundAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Future_Unsuccessfuly_Wrong_Patient()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(2), new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInFuture(1);
            foundAppointments.ShouldBeEmpty();
        }

        private static IAppointmentRepository CreateStubRepository(int id)
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "04/02/2019", 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "11/01/2016", 1, 2, new List<Referral>(), "1");


            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(It.IsAny<int>())).Callback((int id) =>
            {

            }
            ).Returns(appointments.FindAll(app => app.PatientUserId == id));

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateStubRepositoryForFuture(int id)
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            DateTime dt = DateTime.Now.AddDays(10);
            String date = dt.ToString("dd/MM/yyyy");
            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), date, 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), date, 1, 2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(It.IsAny<int>())).Callback((int id) =>
            {

            }
             ).Returns(appointments.FindAll(app => app.PatientUserId == id));

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateStubRepositoryForNextTwoDays()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");



            DateTime dt = DateTime.Now.AddDays(1);
            String date = dt.ToString("dd/MM/yyyy");
            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), date, 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), date, 1, 2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(1)).Returns(appointments);

            return stubRepository.Object;
        }
    }
}
