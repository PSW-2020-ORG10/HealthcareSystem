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
        public void Block_Patient_Successfuly()
        {
            PatientService service = new PatientService(CreateStubRepository(), new Mock<IEmailVerificationService>().Object);
            PatientUser patient = service.BlockPatient(1);
            patient.isBlocked.ShouldBe(true);
        }


        private static IPatientsRepository CreateStubRepository()
        {
            var stubRepository = new Mock<IPatientsRepository>();

            var patients = new List<PatientUser>();

            PatientUser patient1 = new PatientUser(1, "Pera2", "Peric", "Male", "1234", "2/2/2020", "123", "212313", "Alergija", "Grad", false, "email", "pass", false, "Grad2", "Roditelj", null);
          
            patients.Add(patient1);

            stubRepository.Setup(m => m.FindOne(1)).Returns(patients.SingleOrDefault(pat => pat.id == 1));
            stubRepository.Setup(m => m.BlockPatient(It.IsAny<PatientUser>())).Callback((PatientUser patient) =>
            {
                PatientUser pat = (patients.SingleOrDefault(pat => pat.id == 1));
                pat.isBlocked = true;
            }
            ).Returns(patient1);


            return stubRepository.Object;
        }

    }
}