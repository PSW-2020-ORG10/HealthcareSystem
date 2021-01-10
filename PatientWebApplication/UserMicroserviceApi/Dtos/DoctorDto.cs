using System;
using System.Collections.Generic;
using System.Text;

namespace UserMicroserviceApi.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string Specialty { get; set; }

        public DoctorDto(int id, string nameAndSurname, string specialty)
        {
            Id = id;
            NameAndSurname = nameAndSurname;
            Specialty = specialty;
        }
    }
}
