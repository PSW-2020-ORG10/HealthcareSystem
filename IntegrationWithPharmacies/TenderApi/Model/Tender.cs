using System;

namespace TenderApi.Model
{
    public class Tender : Entity
    {
        public DateTime ActiveUntil { get; set; }
        public bool Closed { get; set; }

        public Tender() : base() { }

        public Tender(int id, DateTime date, bool closed) : base(id)
        {
            ActiveUntil = date;
            Closed = closed;
        }
        public Tender(DateTime date, bool closed)
        {
            ActiveUntil = date;
            Closed = closed;
        }
    }
}
