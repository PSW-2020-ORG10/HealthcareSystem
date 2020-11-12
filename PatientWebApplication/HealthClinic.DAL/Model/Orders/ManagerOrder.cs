using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
{
    public class ManagersOrder : Entity
    {
        public bool isUrgent { get; set; }
        public virtual List<DoctorsOrder> listOfDoctorsOrders { get; set; }
        public DateTime date { get; set; }
        public bool isOrdered { get; set; }

        public ManagersOrder() : base() { }
        public ManagersOrder(int id, bool isUrgent, List<DoctorsOrder> listOfDoctorsOrders, DateTime date, bool isOrdered) : base(id)
        {
            this.isUrgent = isUrgent;
            this.listOfDoctorsOrders = listOfDoctorsOrders;
            this.date = date;
            this.isOrdered = isOrdered;
        }
    }
}
