/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/

using HCI_wireframe.Model.Doctor;
using System;
using System.Collections.Generic;


namespace Class_diagram.Model.Hospital
{
   public class Medicine : Equipment
    {
        public List<String> room { get; set; }
        public DoctorUser doctor { get; set; }
        public String description { get; set; }
        public Boolean confirmed { get; set; }

        public Medicine(int id, String name, int quantity, string description, List<String> r, DoctorUser dr, Boolean comf) : base(id, name, quantity, r)
        {
            this.doctor = dr;
            this.description = description;
            this.room = r;
            this.confirmed = comf;
        }
        public Medicine()
        {
        }
    }
}