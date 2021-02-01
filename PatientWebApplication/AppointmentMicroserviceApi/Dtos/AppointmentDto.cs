using AppointmentMicroserviceApi.Doctor;
using System.Collections.Generic;

namespace AppointmentMicroserviceApi.Dtos
{
    public class AppointmentDto
    {
        public string DoctorNameAndSurname { get; set; }
        public List<Referral> Referral { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }

        public AppointmentDto(string doctorNameAndSurname, List<Referral> referral, string date, int id)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            Referral = referral;
            Date = date;
            Id = id;
        }
    }
}
