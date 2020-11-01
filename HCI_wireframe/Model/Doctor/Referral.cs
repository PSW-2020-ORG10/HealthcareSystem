/***********************************************************************
 * Module:  Referral.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Doctor.Referral
 ***********************************************************************/
using System;
using Class_diagram.Model.Patient;
namespace Class_diagram.Model.Doctor
{

    public class Referral : Entity
    {

        public String medicine { get; set; }
        public String takeMedicineUntil { get; set; }
        public int quantityPerDay { get; set; }
        public String classify { get; set; }
        public String comment { get; set; }

        public Referral() : base() { }
        public Referral(int id, String medicine, String takeMedicineUntil, int quantityPerDay, String classify, String comment) : base(id)

        {
            this.medicine = medicine;
            this.takeMedicineUntil = takeMedicineUntil;
            this.quantityPerDay = quantityPerDay;
            this.classify = classify;
            this.comment = comment;

        }
    }
}