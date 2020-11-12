using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
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
