using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Orders
{
    public class FinishedOrder : Entity
    {
        public virtual List<Medicine> listOfMedicines { get; set; }

        public FinishedOrder() : base() { }

        public FinishedOrder(int id, List<Medicine> listOfMedicines) : base(id)
        {
            this.listOfMedicines = listOfMedicines;
        }

    }
}
