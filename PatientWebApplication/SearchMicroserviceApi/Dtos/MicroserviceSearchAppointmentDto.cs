using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceSearchAppointmentDto
    {
        public int Id { get; set; }
        public MicroserviceDoctorDto Doctor { get; set; }
        public List<MicroserviceReferralDto> Referrals { get; set; }
        public string Date { get; set; }
        public string RoomId { get; set; }

        public MicroserviceSearchAppointmentDto(int id, MicroserviceDoctorDto doctor, string date, string roomId, List<MicroserviceReferralDto> referrals)
        {
            Id = id;
            Doctor = doctor;
            Date = date;
            RoomId = roomId;
            Referrals = referrals;
        }

        public override bool Equals(object obj)
        {
            return obj is MicroserviceSearchAppointmentDto dto &&
                   Id == dto.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}
