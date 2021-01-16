using AppointmentMicroserviceApi.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public class MicroservicePatientUserAdapter
    {
        public static MicroservicePatientUserDto PatientToMicroservicePatinentUserDto(PatientUser patient)
        {
            return new MicroservicePatientUserDto(patient.Id, patient.FirstName, patient.SecondName, patient.Gender, patient.DateOfBirth);
        }
    }
}
