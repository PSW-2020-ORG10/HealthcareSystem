using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class MicroserviceDoctorDto
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String Speciality { get; set; }
        public String Ordination { get; set; }

        public MicroserviceDoctorDto(int id, string name,string surname, string speciality, string ordination)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Speciality = speciality;
            Ordination = ordination;
        }
    }
}
