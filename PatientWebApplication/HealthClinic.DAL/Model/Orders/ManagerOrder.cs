using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
{
    public class ManagersOrder : Entity
    {
        public Boolean IsUrgent { get; set; }
        public virtual List<DoctorsOrder> ListOfDoctorsOrders { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsOrdered { get; set; }

        public ManagersOrder() : base() { }
        public ManagersOrder(int id, Boolean isUrgent, List<DoctorsOrder> listOfDoctorsOrders, DateTime date, Boolean isOrdered) : base(id)
        {
            IsUrgent = isUrgent;
            ListOfDoctorsOrders = listOfDoctorsOrders;
            Date = date;
            IsOrdered = isOrdered;
        }
    }
}
