using AppointmentMicroserviceApi.Model;

namespace AppointmentMicroserviceApi.Doctor
{
    public class OperationReferral : Entity
    {
        public string Medicine { get; set; }
        public string TakeMedicineUntil { get; set; }
        public int QuantityPerDay { get; set; }
        public string Classify { get; set; }
        public string Comment { get; set; }
        public int OperationId { get; set; }

        public OperationReferral() : base() { }
        public OperationReferral(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;

        }

        public OperationReferral(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment, int appointmentId) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
            OperationId = appointmentId;
        }
    }
}
