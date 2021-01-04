using HealthClinic.CL.Model.Patient;
using System;


namespace HealthClinic.CL.Model.Orders
{
    public class DoctorsOrder : Entity
    {
        public Boolean IsUrgent { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Boolean IsOrdered { get; set; }
        public Boolean IsFinished { get; set; }

        public DoctorsOrder() : base() { }
        public DoctorsOrder(int id, Boolean isUrgent, DateTime dateBegin, DateTime dateEnd, Boolean isOrdered, Boolean isFinished) : base(id)
        {
            IsUrgent = isUrgent;
            DateStart = dateBegin;
            DateEnd = dateEnd;
            IsOrdered = isOrdered;
            IsFinished = isFinished;
        }
        public DoctorsOrder(Boolean isUrgent, DateTime dateBegin, DateTime dateEnd, Boolean isOrdered, Boolean isFinished)
        {
            IsUrgent = isUrgent;
            DateStart = dateBegin;
            DateEnd = dateEnd;
            IsOrdered = isOrdered;
            IsFinished = isFinished;
        }
    }
}
