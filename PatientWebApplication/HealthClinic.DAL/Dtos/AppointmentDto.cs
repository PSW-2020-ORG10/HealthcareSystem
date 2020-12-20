using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class AppointmentDto
    {
        public String DoctorNameAndSurname { get; set; }
        public List<Referral> Referral { get; set; }
        public string Date { get; set; }

        public AppointmentDto(string doctorNameAndSurname, List<Referral> referral, string date)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            Referral = referral;
            Date = date;
        }
    }
}
