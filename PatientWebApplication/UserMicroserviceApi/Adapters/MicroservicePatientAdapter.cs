using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public static class MicroservicePatientAdapter
    {
        public static MicroservicePatientDto PatientToMicroservicePatinentDto(PatientUser patient)
        {
            return new MicroservicePatientDto(patient.id, patient.firstName, patient.secondName);
        }
    }
}
