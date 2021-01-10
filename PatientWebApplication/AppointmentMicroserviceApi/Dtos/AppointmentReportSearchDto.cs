using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentMicroserviceApi.Dtos
{
    public class AppointmentReportSearchDto
    {
        public string DoctorNameAndSurname { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string AppointmentType { get; set; }
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
