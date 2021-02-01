﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentMicroserviceApi.Dtos
{
    public class RecommendedAppointmentDto
    {

        public int DoctorId { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Priority { get; set; }
        public int PatientId { get; set; }

        public RecommendedAppointmentDto() { }

        public RecommendedAppointmentDto(int doctorId, string start, string end, string priority, int id)
        {
            DoctorId = doctorId;
            Start = start;
            End = end;
            Priority = priority;
            PatientId = id;
        }
    }
}
