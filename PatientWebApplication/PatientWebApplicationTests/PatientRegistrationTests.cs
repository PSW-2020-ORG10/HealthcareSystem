using HealthClinic.CL.Dtos;
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
    public class PatientRegistrationTests 
    {
        [Fact]
        public void Create_Registration_Successfuly()
        {

            PatientService service = new PatientService(CreateStubRepository());

            PatientDto dto = new PatientDto("Pera2", "Peric", "Male", "1234", "11/11/2000", "1231412", "21312312", "Alergija", "Grad", "email@gmail.com", "pass", false, "Grad2", "Roditelj", "", "");


            PatientUser patient =  service.Create(dto);
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
