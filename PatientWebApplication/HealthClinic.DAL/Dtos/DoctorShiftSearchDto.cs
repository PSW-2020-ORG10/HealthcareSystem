using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class DoctorShiftSearchDto
    {
        public int DoctorId { get; set; }
        public String Date { get; set; }

        public DoctorShiftSearchDto(int doctorId, string date)
        {
            DoctorId = doctorId;
            Date = date;  
        }
    }
}
