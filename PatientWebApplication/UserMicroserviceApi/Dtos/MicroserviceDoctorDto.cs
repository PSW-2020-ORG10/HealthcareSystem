using System;
using System.Collections.Generic;
using System.Text;

namespace UserMicroserviceApi.Dtos
{
    public class MicroserviceDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Speciality { get; set; }
        public string Ordination { get; set; }

        public MicroserviceDoctorDto(int id, string name, string surname, string speciality, string ordination)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Speciality = speciality;
            Ordination = ordination;
        }
    }
}
