using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
{
    public class DoctorsOrder : Entity
    {
        public bool isUrgent { get; set; }
        public virtual List<Medicine> listOfMedicines { get; set; }
        public DateTime date { get; set; }
        public bool isOrdered { get; set; }

        public DoctorsOrder() : base() { }
        public DoctorsOrder(int id, bool isUrgent, List<Medicine> listOfMedicines, DateTime date, bool isOrdered) : base(id)
        {
            this.isUrgent = isUrgent;
            this.listOfMedicines = listOfMedicines;
            this.date = date;
            this.isOrdered = isOrdered;
        }
    }
}
