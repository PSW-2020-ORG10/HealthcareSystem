
/***********************************************************************
 * Module:  PhoneNumber.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Model.Patient.PhoneNumber
 ***********************************************************************/
using System;

namespace UserMicroserviceApi.Model
{
    public class PhoneNumber : Entity
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public PhoneNumber(int id, int number, string name) : base(id)
        {
            Number = number;
            Name = name;
        }
        public PhoneNumber() { }
    }
}