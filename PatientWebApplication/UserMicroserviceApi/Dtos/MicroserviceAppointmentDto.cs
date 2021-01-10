using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceApi.Dtos
{
    public class MicroserviceAppointmentDto
    {
        public int PatientUserId { get; set; }
        public String Date { get; set; }
        public String CancelDateString { get; set; }
        public bool IsCanceled { get; set; }

        public MicroserviceAppointmentDto(int patientUserId, string date, string cancelDateString, bool isCanceled)
        {
            PatientUserId = patientUserId;
            Date = date;
            CancelDateString = cancelDateString;
            IsCanceled = isCanceled;
        }
    }
}
