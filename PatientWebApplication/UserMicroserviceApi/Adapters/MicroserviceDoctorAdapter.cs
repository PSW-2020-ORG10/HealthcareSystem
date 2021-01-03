using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public static class MicroserviceDoctorAdapter
    {
        public static MicroserviceDoctorDto DoctorToMicroserviceDoctorDto(DoctorUser doctor)
        {
            return new MicroserviceDoctorDto(doctor.id, doctor.firstName, doctor.secondName, doctor.speciality, doctor.ordination);
        }

        public static List<MicroserviceDoctorDto> DoctorListToMicroserviceDoctorDtoList(List<DoctorUser> doctors)
        {
            List<MicroserviceDoctorDto> microserviceDoctorDtos = new List<MicroserviceDoctorDto>();
            foreach(DoctorUser doctor in doctors)
            {
                microserviceDoctorDtos.Add(DoctorToMicroserviceDoctorDto(doctor));
            }
            return microserviceDoctorDtos;
        }
    }
}
