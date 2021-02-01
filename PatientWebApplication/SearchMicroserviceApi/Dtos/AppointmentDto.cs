using System.Collections.Generic;

namespace SearchMicroserviceApi.Dtos
{
    public class AppointmentDto
    {
        public string DoctorNameAndSurname { get; set; }
        public List<MicroserviceReferralDto> Referrals { get; set; }
        public string Date { get; set; }
        public int Id { get; set; }

        public AppointmentDto(string doctorNameAndSurname, List<MicroserviceReferralDto> referrals, string date, int id)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            Referrals = referrals;
            Date = date;
            Id = id;
        }
    }
}
