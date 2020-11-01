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
        public Boolean isConfirmed { get; set; }

        public Medicine(int id, String name, int quantity, string description, List<String> room, DoctorUser doctor, Boolean isConfirmed) : base(id, name, quantity, room)
        {
            this.doctor = doctor;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }
        public Medicine()
        {
        }
    }
}