using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentMicroserviceApi.Dtos
{
    public class MicroserviceAppointmentDto
    {
        public int PatientUserId { get; set; }
        public string Date { get; set; }
        public string CancelDateString { get; set; }
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
