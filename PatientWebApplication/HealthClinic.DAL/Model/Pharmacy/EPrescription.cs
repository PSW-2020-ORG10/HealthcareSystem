using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Model.Pharmacy
{
    public class EPrescription : Entity
    {
        public String Pharmacy { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String MedicalIDNumber { get; set; }
        public String Medicine { get; set; }
        public int Quantity { get; set; }
        public String Usage { get; set; }
        public EPrescription() : base() { }

        public EPrescription(String pharmacy, int id, String name, String surname, String medicalIDNumber, String medicine, int quantity, String usage) : base(id)
        {
            Pharmacy = pharmacy;
            Name = name;
            Surname = surname;
            MedicalIDNumber = medicalIDNumber;
            Medicine = medicine;
            Quantity = quantity;
            Usage = usage;
        }
        public EPrescription(String pharmacy, String name, String surname, String medicalIDNumber, String medicine, int quantity, String usage)
        {
            Pharmacy = pharmacy;
            Name = name;
            Surname = surname;
            MedicalIDNumber = medicalIDNumber;
            Medicine = medicine;
            Quantity = quantity;
            Usage = usage;
        }
    }
}
