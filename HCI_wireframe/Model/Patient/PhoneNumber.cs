
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
        public int number { get; set; }
        public String name { get; set; }
        public PhoneNumber(int id, int number, String name) : base(id)
        {
            this.number = number;
            this.name = name;
        }
        public PhoneNumber() { }
    }
}