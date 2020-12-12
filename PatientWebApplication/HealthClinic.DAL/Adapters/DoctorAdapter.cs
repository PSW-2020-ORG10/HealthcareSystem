using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class DoctorAdapter
    {
        public DoctorDto DoctorToDoctorDto(DoctorUser doctor)
        {
            return new DoctorDto(doctor.id, doctor.firstName + " " + doctor.secondName, doctor.speciality);
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
