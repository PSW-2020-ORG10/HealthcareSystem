﻿using AppointmentMicroserviceApi.Doctor;
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
    public class CancelAppointmentsTests
    {
        [Fact]
        public void Cancel_Appointment_Successfuly()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepository(), new OperationService(new Mock<IOperationRepository>().Object));
            DoctorAppointment appointment = service.CancelAppointment(4);
            appointment.IsCanceled.ShouldBe(true);
        }

        [Fact]
        public void Cancel_Appointment_In_Past()
        {
            RegularAppointmentService service = new RegularAppointmentService(CreateStubRepositoryInPast(), new OperationService(new Mock<IOperationRepository>().Object));
            DoctorAppointment appointment = service.CancelAppointment(4);
            appointment.ShouldBeNull();
        }

        private static IAppointmentRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();
            DateTime dt = DateTime.Now.AddDays(10);
            String date = dt.ToString("dd/MM/yyyy");
            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), date, 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), date, 2, 2, new List<Referral>(), "1");



            appointments.Add(appointment1);
            appointments.Add(appointment2);

            

            stubRepository.Setup(m => m.GetByid(4)).Returns(appointments.SingleOrDefault(app => app.Id == 4));
            stubRepository.Setup(m => m.CancelAppointment(It.IsAny<DoctorAppointment>())).Callback((DoctorAppointment appointment) =>
            {
                DoctorAppointment app = (appointments.SingleOrDefault(app => app.Id == 4));
                app.IsCanceled = true;
            }
            ).Returns(appointment1); 


            return stubRepository.Object;
        }

        private static IAppointmentRepository CreateStubRepositoryInPast()
        {
            var stubRepository = new Mock<IAppointmentRepository>();

            var appointments = new List<DoctorAppointment>();

            DoctorUser doctor1 = new DoctorUser(1, "Konstantin", "Davidovic", "1234", "2/2/2020", "123", "email", "pass", "Grad",
             200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");
            DoctorUser doctor2 = new DoctorUser(2, "Novak", "Maric", "12345", "2/2/2020", "123", "email", "pass", "Grad",
              200.0, false, "Specialty", new List<DoctorNotification>(), "Ordination 1");

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
            PatientUser patient2 = new PatientUser(2, "Pera3", "Peric", "Female", "1234", "2/2/2020", "123", "2112313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);

            DoctorAppointment appointment1 = new DoctorAppointment(4, new TimeSpan(), "17/05/2020", 1, 1, new List<Referral>(), "1");
            DoctorAppointment appointment2 = new DoctorAppointment(5, new TimeSpan(), "17/04/2020", 2, 2, new List<Referral>(), "1");

            appointments.Add(appointment1);
            appointments.Add(appointment2);

            stubRepository.Setup(m => m.GetByid(4)).Returns(appointments.SingleOrDefault(app => app.Id == 4));
            stubRepository.Setup(m => m.CancelAppointment(appointment1)).Returns(appointments.SingleOrDefault(app => app.Id == 4));


            return stubRepository.Object;
        }
    }
}
