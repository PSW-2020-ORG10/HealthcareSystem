using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using UserMicroserviceApi.Model;
using UserMicroserviceApi.Repository;
using UserMicroserviceApi.Service;
using Xunit;

namespace PatientWebApplicationTests
{
    public class LoginTests
    {
        [Fact]
        public void Successful_Login()
        {
            LoginService loginService = new LoginService(CreatePatientStubRepository("markomarkovic@gmail.com"), CreateAdminStubRepository("markomarkovic@gmail.com"));
            UserModel patient = loginService.AuthenticateUser(new UserModel(1, "markomarkovic@gmail.com", "password", ""));
            patient.ShouldNotBeNull();
        }

        [Fact]
        public void Unsuccessful_Login_Not_Verified()
        {
            LoginService loginService = new LoginService(CreatePatientStubRepository("kristinapetrovic@gmail.com"), CreateAdminStubRepository("kristinapetrovic@gmail.com"));
            UserModel patient = loginService.AuthenticateUser(new UserModel(1, "kristinapetrovic@gmail.com", "password", ""));
            patient.ShouldBeNull();
        }

        [Fact]
        public void Unsuccessful_Login_Blocked()
        {
            LoginService loginService = new LoginService(CreatePatientStubRepository("petarstanic@gmail.com"), CreateAdminStubRepository("petarstanic@gmail.com"));
            UserModel patient = loginService.AuthenticateUser(new UserModel(1, "petarstanic@gmail.com", "password", ""));
            patient.ShouldBeNull();
        }

        [Fact]
        public void Unsuccessful_Login_Wrong_Values()
        {
            LoginService loginService = new LoginService(CreatePatientStubRepository("wrongmail@gmail.com"), CreateAdminStubRepository("wrongmail@gmail.com"));
            UserModel patient = loginService.AuthenticateUser(new UserModel(1, "wrongmail@gmail.com", "wrongpassword", ""));
            patient.ShouldBeNull();
        }

        [Fact]
        public void Successful_Login_Administrator()
        {
            LoginService loginService = new LoginService(CreatePatientStubRepository("admin@gmail.com"), CreateAdminStubRepository("admin@gmail.com"));
            UserModel admin = loginService.AuthenticateUser(new UserModel(1, "admin@gmail.com", "password", ""));
            admin.ShouldNotBeNull();
        }

        private static IPatientsRepository CreatePatientStubRepository(string mail)
        {
            var stubRepository = new Mock<IPatientsRepository>();

            var patients = new List<PatientUser>();

            PatientUser patient1 = new PatientUser(1, "Marko", "Markovic", "Male", "1234", "02/02/1980", "123", "2112313", "Alergija", "Sutjetska 8, Novi Sad", false, "markomarkovic@gmail.com", "password", false, "Novi Sad", "Roditelj", null);
            patient1.isVerified = true;
            PatientUser patient2 = new PatientUser(2, "Kristina", "Petrovic", "Female", "1234", "11/11/1972", "123", "2112313", "Alergija", "Sutjetska 8, Novi Sad", false, "kristinapetrovic@gmail.com", "password", false, "Novi Sad", "Roditelj", null);
            PatientUser patient3 = new PatientUser(3, "Petar", "Stanic", "Male", "1234", "11/11/1972", "123", "2112313", "Alergija", "Sutjetska 8, Novi Sad", false, "petarstanic@gmail.com", "password", false, "Novi Sad", "Roditelj", null);
            patient3.isBlocked = true;

            patients.Add(patient1);
            patients.Add(patient2);
            patients.Add(patient3);

            stubRepository.Setup(m => m.GetAll()).Returns(patients);

            PatientUser patientUser = new PatientUser();

            stubRepository.Setup(m => m.GetByLoginInfo(It.IsAny<UserModel>())).Callback((UserModel model) =>
            {
                patientUser = patients.SingleOrDefault(app => app.email.Equals(mail) && app.isVerified == true && app.isBlocked == false);
                UserModel modelPatient = new UserModel(patientUser.id, patientUser.email, patientUser.password, "patient");
            }
            ).Returns(patientUser);

            return stubRepository.Object;
        }

        private static IAdministratorRepository CreateAdminStubRepository(string mail)
        {
            var stubRepository = new Mock<IAdministratorRepository>();

            var admins = new List<Administrator>();

            var admin = new Administrator(1, "Ana", "Anicic","123", "11/11/1972", "2144245", "admin@gmail.com", "password", "Novi Sad", 1000.0);

            admins.Add(admin);

            stubRepository.Setup(m => m.GetAll()).Returns(admins);

            stubRepository.Setup(m => m.GetByLoginInfo(It.IsAny<UserModel>())).Callback((UserModel model) =>
            {
                Administrator administrator = admins.SingleOrDefault(app => app.email.Equals(mail));
                UserModel modelAdministrator = new UserModel(administrator.id, administrator.email, administrator.password, "admin");
            }
            ).Returns(admin);

            return stubRepository.Object;
        }
    }
}
