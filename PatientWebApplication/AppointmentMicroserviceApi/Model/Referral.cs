/***********************************************************************
 * Module:  Referral.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/
using AppointmentMicroserviceApi.Model;

namespace AppointmentMicroserviceApi.Doctor
{

    public class Referral : Entity
    {
        public string Medicine { get; set; }
        public string TakeMedicineUntil { get; set; }
        public int QuantityPerDay { get; set; }
        public string Classify { get; set; }
        public string Comment { get; set; }
        public int AppointmentId { get; set; }

        public Referral() : base() { }
        public Referral(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;

        }

        public Referral(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment, int appointmentId) : base(id)

        {
            Medicine = medicine;
            TakeMedicineUntil = takeMedicineUntil;
            QuantityPerDay = quantityPerDay;
            Classify = classify;
            Comment = comment;
            AppointmentId = appointmentId;
        }
    }
}