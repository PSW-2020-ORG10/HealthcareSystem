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
    public class MyAppointmentsTests
    {

        [Fact]
        public void Get_Appointments_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatient(1);
            foundAppointments.ShouldNotBeNull();
        }

        [Fact]
        public void Get_Appointments_Unsuccessfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatient(1);
            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForNextTwoDays(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Unsuccessfuly_Because_They_Happend_Before()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldBeEmpty();
        }


        [Fact]
        public void Get_Appointments_In_Next_Two_Days_Unsuccessfuly_Because_They_Happend_After()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInTwoDays(1);
            foundAppointments.ShouldBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Future_Successfuly()
        { 
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryForFuture(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInFuture(1);
            foundAppointments.ShouldNotBeEmpty();
        }

        [Fact]
        public void Get_Appointments_In_Future_Unsuccessfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new DoctorService(new Mock<IOperationRepository>().Object, CreateStubRepository(), new Mock<IEmployeesScheduleRepository>().Object, new Mock<IDoctorRepository>().Object), new Mock<IPatientsRepository>().Object, new OperationService(new Mock<IOperationRepository>().Object));
            List<DoctorAppointment> foundAppointments = service.GetAppointmentsForPatientInFuture(1);
            foundAppointments.ShouldBeEmpty();
        }

        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "04/02/2019", patient1, doctor1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "11/01/2016", patient1, doctor2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(1)).Returns(appointments);

            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateStubRepositoryForFuture()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "17/12/2020", patient1, doctor1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "17/12/2020", patient1, doctor2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(1)).Returns(appointments);

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

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "06/12/2020", patient1, doctor1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "06/12/2020", patient1, doctor2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetAppointmentsForPatient(1)).Returns(appointments);

            return stubRepository.Object;
        }
    }
}
