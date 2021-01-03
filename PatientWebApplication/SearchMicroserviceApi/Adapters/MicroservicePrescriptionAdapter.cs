using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Adapters
{
    public static class MicroservicePrescriptionAdapter
    {
        public static MicroservicePrescriptionDto PrescriptionToMicroservicePrescriptionDto(Prescription prescription)
        {
            return new MicroservicePrescriptionDto(Utility.HttpRequests.GetDoctorByIdAsync(prescription.DoctorId).Result, prescription.id, prescription.patientsid, prescription.Medicines, prescription.isUsed, prescription.comment, prescription.DoctorId);
        }

        public static List<MicroservicePrescriptionDto> PrescriptionListToMicroservicePrescriptionDtoList(List<Prescription> prescriptions)
        {
            List<MicroservicePrescriptionDto> microservicePrescriptionDtos = new List<MicroservicePrescriptionDto>();
            foreach(Prescription prescription in prescriptions)
            {
                microservicePrescriptionDtos.Add(PrescriptionToMicroservicePrescriptionDto(prescription));
            }
            return microservicePrescriptionDtos;
        }
    }
}
