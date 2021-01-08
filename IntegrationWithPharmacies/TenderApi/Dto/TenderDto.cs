using System;

namespace TenderApi.Dto
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
