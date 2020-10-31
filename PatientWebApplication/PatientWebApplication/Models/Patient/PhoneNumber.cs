
/***********************************************************************
 * Module:  PhoneNumber.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Model.Patient.PhoneNumber
 ***********************************************************************/
using System;
namespace Class_diagram.Model.Patient
{
    public class PhoneNumber : Entity
    {
        public int Number { get; set; }
        public String Name { get; set; }
        public PhoneNumber(int id, int number, String name) : base(id)
        {
            this.Number = number;
            this.Name = name;
        }
        public PhoneNumber() { }
    }
}