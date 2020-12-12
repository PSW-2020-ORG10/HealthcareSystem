using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Repository;
using HealthClinic.CL.Service;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace PatientWebApplicationTests
{
    public class BlockPatientTests
    {
        [Fact]
        public void Block_Patient_Successffuly()
        {
            PatientService service = new PatientService(CreateStubRepository(), new Mock<IEmailVerificationService>().Object, new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository())));
            PatientUser patient = service.BlockPatient(1);
            patient.isBlocked.ShouldBe(true);
        }

        [Fact]
        public void Block_Patient_Unsuccessffuly()
        {
            PatientService service = new PatientService(CreateStubRepository(), new Mock<IEmailVerificationService>().Object, new RegularAppointmentService(new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorService(new OperationRepository(), new AppointmentRepository(), new EmployeesScheduleRepository(), new DoctorRepository()), new PatientsRepository(), new OperationService(new OperationRepository())));
            PatientUser patient = service.BlockPatient(2);
            patient.ShouldBeNull();
        }

        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();

            var patients = new List<PatientUser>();

            PatientUser blockedPatient = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
          
            patients.Add(blockedPatient);

            stubRepository.Setup(m => m.FindOne(1)).Returns(patients.SingleOrDefault(patientUser => patientUser.id == 1));
            stubRepository.Setup(m => m.BlockPatient(It.IsAny<PatientUser>())).Callback((PatientUser patient) =>
            {
                PatientUser patientUser = (patients.SingleOrDefault(patientUser => patientUser.id == 1));
                patientUser.isBlocked = true;
            }
            ).Returns(blockedPatient);

            return stubRepository.Object;
        }
    }
}