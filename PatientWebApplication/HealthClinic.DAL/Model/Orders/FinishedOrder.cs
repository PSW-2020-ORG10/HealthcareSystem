using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
{
    public class FinishedOrder : Entity
    {
        public virtual List<Medicine> ListOfMedicines { get; set; }

        public FinishedOrder() : base() { }

        public FinishedOrder(int id, List<Medicine> listOfMedicines) : base(id)
        {
            ListOfMedicines = listOfMedicines;
        }

    }
}
