using HealthClinic.BL.Model.Hospital;
using HealthClinic.BL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClinic.BL.Model.Orders
{
    public class PharmacyOffer : Entity
    {
        public string pharmacyName { get; set; }
        public virtual List<Medicine> ListOfMedicies { get; set; }
        public double summPriceOfMedications { get; set; }

        public PharmacyOffer() : base() { }

        public PharmacyOffer(int id, string pharmacyName, List<Medicine> ListOfMedicies, double summPriceOfMedications) : base(id)
        {
            this.pharmacyName = pharmacyName;
            this.ListOfMedicies = ListOfMedicies;
            this.summPriceOfMedications = summPriceOfMedications;
        }
    }

}
