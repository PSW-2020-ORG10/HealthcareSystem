using System;


namespace HealthClinic.CL.Dtos
{
    public class  DoctorsOrderDto
    {
        public Boolean IsUrgent { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public Boolean IsOrdered { get; set; }
        public Boolean IsFinished { get; set; }

        public DoctorsOrderDto(){ }
  
        public DoctorsOrderDto(Boolean isUrgent, DateTime dateBegin, DateTime dateEnd, Boolean isOrdered, Boolean isFinished)
        {
            IsUrgent = isUrgent;
            DateStart = dateBegin;
            DateEnd = dateEnd;
            IsOrdered = isOrdered;
            IsFinished = isFinished;
        }
    }
}
