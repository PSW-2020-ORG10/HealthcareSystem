using System;

namespace TenderApi.Model
{
    public class Tender : Entity
    {
        public DateTime ExpirationDate { get; set; }
        public bool Closed { get; set; }

        public Tender() : base() { }

        public Tender(int id, DateTime expirationDate, bool closed) : base(id)
        {
            ExpirationDate = expirationDate;
            Closed = closed;
        }
        public Tender(DateTime expirationDate, bool closed)
        {
            ExpirationDate = expirationDate;
            Closed = closed;
        }
    }
}
