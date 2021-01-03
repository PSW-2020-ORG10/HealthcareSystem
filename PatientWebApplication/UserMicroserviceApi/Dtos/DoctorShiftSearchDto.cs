using System;
using System.Collections.Generic;
using System.Text;

namespace UserMicroserviceApi.Dtos
{
    public class DoctorShiftSearchDto
    {
        public int DoctorId { get; set; }
        public string Date { get; set; }

        public DoctorShiftSearchDto(int doctorId, string date)
        {
            DoctorId = doctorId;
            Date = date;
        }
    }
}
