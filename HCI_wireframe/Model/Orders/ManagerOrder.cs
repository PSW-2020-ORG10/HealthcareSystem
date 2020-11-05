using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Orders
{
    public class ManagersOrder : Entity
    {
        public bool isUrgent { get; set; }
        public virtual List<DoctorsOrder> listOfDoctorsOrders { get; set; }
        public DateTime date { get; set; }
        public bool isOrdered { get; set; }

        public ManagersOrder() : base(){ }
        public ManagersOrder(int id, bool isUrgent, List<DoctorsOrder> listOfDoctorsOrders, DateTime date, bool isOrdered) : base(id)
        {
            this.isUrgent = isUrgent;
            this.listOfDoctorsOrders = listOfDoctorsOrders;
            this.date = date;
            this.isOrdered = isOrdered;
        }
    }
}
