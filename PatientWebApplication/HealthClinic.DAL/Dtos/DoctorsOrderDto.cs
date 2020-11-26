using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class  DoctorsOrderDto
    {
        public bool isUrgent { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isOrdered { get; set; }
        public bool isFinished { get; set; }

        public DoctorsOrderDto(){ }
        public DoctorsOrderDto(bool isUrgent, DateTime dateBegin, DateTime dateEnd, bool isOrdered, bool isFinished)
        {
            this.isUrgent = isUrgent;
            this.dateStart = dateBegin;
            this.dateEnd = dateEnd;
            this.isOrdered = isOrdered;
            this.isFinished = isFinished;
        }
    }
}
