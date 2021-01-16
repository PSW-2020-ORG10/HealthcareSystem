using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Dtos
{
    public class MicroservicePatientUserDto
    {
        public int Id;
        public string Name;
        public string Surname;
        public string Gender;
        public string DateOfBirth;

        public MicroservicePatientUserDto(int id, string name, string surname, string gender, string dateOfBirth)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Gender = gender;
            DateOfBirth = dateOfBirth;
        }
    }
}
