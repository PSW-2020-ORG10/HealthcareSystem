using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class AppointmentReportSearchDto
    {
        public String DoctorNameAndSurname { get; set; }
        public String Start { get; set; }
        public String End { get; set; }
        public String AppointmentType { get; set; }
        public int PatientId { get; set; }
        public AppointmentReportSearchDto() { }

        public AppointmentReportSearchDto(string doctorNameAndSurname, string start, string end, string appointmentType, int patientId)
        {
            DoctorNameAndSurname = doctorNameAndSurname;
            Start = start;
            End = end;
            AppointmentType = appointmentType;
            PatientId = patientId;
        }
    }
}
