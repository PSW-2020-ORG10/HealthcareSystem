using System.Collections.Generic;
using UserMicroserviceApi.Dtos;
using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Adapters
{
    public class DoctorAdapter
    {
        public DoctorDto DoctorToDoctorDto(DoctorUser doctor)
        {
            return new DoctorDto(doctor.Id, doctor.FirstName + " " + doctor.SecondName, doctor.Speciality);
        }

        public List<DoctorDto> ConvertDoctorListToDoctorDtoList(List<DoctorUser> doctors)
        {
            List<DoctorDto> doctorsDto = new List<DoctorDto>();
            foreach (DoctorUser doctor in doctors)
            {
                doctorsDto.Add(DoctorToDoctorDto(doctor));
            }
            return doctorsDto;
        }
    }
}
