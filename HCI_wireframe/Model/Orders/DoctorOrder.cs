using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Orders
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
