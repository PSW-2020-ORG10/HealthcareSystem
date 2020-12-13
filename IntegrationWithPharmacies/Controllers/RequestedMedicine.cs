using HealthClinic.CL.Model.Hospital;

namespace IntegrationWithPharmacies.Controllers
{
    public class RequestedMedicine
    {
        public Medicine Medicine { get; set; }
        public int Quantity { get; set; }

        public RequestedMedicine() { }

        public RequestedMedicine(Medicine medicine, int quantity)
        {
            Medicine = medicine;
            Quantity = quantity;
        }
    }
}
