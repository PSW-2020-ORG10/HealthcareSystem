
using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.CL.Model.Orders
{
    public class DoctorsOrder : Entity
    {
        public bool isUrgent { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isOrdered { get; set; }
        public bool isFinished { get; set; }

        public DoctorsOrder() : base() { }
        public DoctorsOrder(int id, bool isUrgent, DateTime dateBegin, DateTime dateEnd, bool isOrdered, bool isFinished) : base(id)
        {
            this.isUrgent = isUrgent;
            this.dateStart = dateBegin;
            this.dateEnd = dateEnd;
            this.isOrdered = isOrdered;
            this.isFinished = isFinished;
        }
    }
}
