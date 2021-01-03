
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
        public int number { get; set; }
        public string name { get; set; }
        public PhoneNumber(int id, int number, string name) : base(id)
        {
            this.number = number;
            this.name = name;
        }
        public PhoneNumber() { }
    }
}