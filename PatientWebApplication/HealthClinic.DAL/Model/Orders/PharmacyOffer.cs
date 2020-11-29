using HealthClinic.CL.Model.Hospital;
using HealthClinic.CL.Model.Patient;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Orders
{
    public class PharmacyOffer : Entity
    {
        public string PharmacyName { get; set; }
        public virtual List<Medicine> ListOfMedicies { get; set; }
        public double SummPriceOfMedications { get; set; }

        public PharmacyOffer() : base() { }

        public PharmacyOffer(int id, string pharmacyName, List<Medicine> listOfMedicies, double summPriceOfMedications) : base(id)
        {
            PharmacyName = pharmacyName;
            ListOfMedicies = listOfMedicies;
            SummPriceOfMedications = summPriceOfMedications;
        }
    }

}
