using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentMicroserviceApi.Dtos
{
    public class MicroserviceShiftDto
    {
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public MicroserviceShiftDto(int id, string startTime, string endTime)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
        }
    }
}
