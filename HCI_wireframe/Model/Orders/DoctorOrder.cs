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
        public virtual Dictionary<Medicine,int> listOfMedicines { get; set; }
        public DateTime dateStart { get; set; }
        public DateTime dateEnd { get; set; }
        public bool isOrdered { get; set; }
        public bool isFinished { get; set; }

        public DoctorsOrder() : base() { }
        public DoctorsOrder(int id, bool isUrgent, Dictionary<Medicine,int> listOfMedicines, DateTime dateBegin, DateTime dateEnd, bool isOrdered) : base(id)
        {
            this.isUrgent = isUrgent;
            this.listOfMedicines = listOfMedicines;
            this.dateStart = dateBegin;
            this.dateEnd = dateEnd;
            this.isOrdered = isOrdered;
        }
    }
}
