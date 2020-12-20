using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class AvailableAppointmentsSearchDto
    {
        public string Date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }

        public AvailableAppointmentsSearchDto(string date, int patientId, int doctorId)
        {
            Date = date;
            PatientId = patientId;
            DoctorId = doctorId;
        }
    }
}
