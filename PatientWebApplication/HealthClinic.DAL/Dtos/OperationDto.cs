using HealthClinic.CL.Model.Doctor;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class OperationDto
    {
        public String DoctorNameAndSurname { get; set; }
        public OperationReferral OperationReferral { get; set; }
        public string Date { get; set; }

        public OperationDto(string doctorNameAndSurname, OperationReferral referral, string date)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            OperationReferral = referral;
            Date = date;
        }
    }
}
