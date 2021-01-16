using System.Collections.Generic;

namespace SearchMicroserviceApi.Dtos
{
    public class AppointmentDto
    {
        public string DoctorNameAndSurname { get; set; }
        public List<MicroserviceReferralDto> Referral { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }

        public AppointmentDto(string doctorNameAndSurname, List<MicroserviceReferralDto> referral, string date, int id)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            Referral = referral;
            Date = date;
            Id = id;
        }
    }
}
