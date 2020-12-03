using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class DoctorDto
    {
        public String NameAndSurname { get; set; }
        public String Specialty { get; set; }

        public DoctorDto(string nameAndSurname, string specialty)
        {
            NameAndSurname = nameAndSurname;
            Specialty = specialty;
        }
    }
}
