using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationWithPharmacies.Controllers
{
    public class Prescription
    {
        public String Pharmacy { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public String MedicalIDNumber { get; set; }
        public String Medicine { get; set; }
        public int Quantity { get; set; }
        public String Usage { get; set; }
        public Prescription() { }

        public Prescription(String name, String surname, String medicalIDNumber,String medicine, int quantity,String usage)
        {
            Name = name;
            Surname = surname;
            MedicalIDNumber = medicalIDNumber;
            Medicine = medicine;
            Quantity = quantity;
            Usage = usage;
        }
    }
}
