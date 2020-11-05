using Class_diagram.Model.Hospital;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Orders
{
    public class PharmacyOffer : Entity
    {
        public String pharmacyName { get; set; }
        public virtual List<Medicine> ListOfMedicies { get; set; }
        public double summPriceOfMedications { get; set; }

        public PharmacyOffer() : base() { }

        public PharmacyOffer(int id, String pharmacyName, List<Medicine> ListOfMedicies, double summPriceOfMedications) : base(id)
        {
            this.pharmacyName = pharmacyName;
            this.ListOfMedicies = ListOfMedicies;
            this.summPriceOfMedications = summPriceOfMedications;
        }
    }

}
