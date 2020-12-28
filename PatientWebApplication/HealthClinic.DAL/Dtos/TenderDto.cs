using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class TenderDto
    {
        public DateTime ActiveUntil { get; set; }
        public bool Closed { get; set; }

        public TenderDto() { }

        public TenderDto(DateTime date, bool closed)
        {
            ActiveUntil = date;
            Closed = closed;
        }
    }
}
