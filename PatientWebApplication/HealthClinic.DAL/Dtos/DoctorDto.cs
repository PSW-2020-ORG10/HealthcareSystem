using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public String NameAndSurname { get; set; }
        public String Specialty { get; set; }

        public DoctorDto(int id, string nameAndSurname, string specialty)
        {
            Id = id;
            NameAndSurname = nameAndSurname;
            Specialty = specialty;
        }
    }
}
