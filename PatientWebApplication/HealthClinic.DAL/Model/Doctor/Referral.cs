/***********************************************************************
 * Module:  Referral.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/
using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Doctor
{

    public class Referral : Entity
    {

        public string medicine { get; set; }
        public string takeMedicineUntil { get; set; }
        public int quantityPerDay { get; set; }
        public string classify { get; set; }
        public string comment { get; set; }

        public Referral() : base() { }
        public Referral(int id, string medicine, string takeMedicineUntil, int quantityPerDay, string classify, string comment) : base(id)

        {
            this.medicine = medicine;
            this.takeMedicineUntil = takeMedicineUntil;
            this.quantityPerDay = quantityPerDay;
            this.classify = classify;
            this.comment = comment;

        }
    }
}