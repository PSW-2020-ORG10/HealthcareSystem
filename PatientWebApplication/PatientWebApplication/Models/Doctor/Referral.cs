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
        public Referral(int id, String p, String take, int quantity, String treatment, String com) : base(id)

        {
            this.medicine = p;
            this.takeMedicineUntil = take;
            this.quantityPerDay = quantity;
            this.classify = treatment;
            this.comment = com;

        }
    }
}