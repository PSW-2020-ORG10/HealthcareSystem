using System;

namespace TenderApi.Dto
{
    public class TenderDto
    {
        public DateTime ExpirationDate { get; set; }
        public bool Closed { get; set; }

        public TenderDto() { }

        public TenderDto(DateTime expirationDate, bool closed)
        {
            ExpirationDate = expirationDate;
            Closed = closed;
        }
    }
}
