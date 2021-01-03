using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SearchMicroserviceApi.Dtos
{
    public class MicroserviceSearchAppointmentDto
    {
        public MicroserviceDoctorDto Doctor { get; set; }
        public string Date { get; set; }
        public string RoomId { get; set; }

        public MicroserviceSearchAppointmentDto(MicroserviceDoctorDto doctor, string date, string roomId)
        {
            Doctor = doctor;
            Date = date;
            RoomId = roomId;
        }
    }
}
