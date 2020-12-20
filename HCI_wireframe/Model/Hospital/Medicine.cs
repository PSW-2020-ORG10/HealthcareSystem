/***********************************************************************
 * Module:  Medicine.cs
 * Author:  Lidija
 * Purpose: Definition of the Class Manager.Medicine
 ***********************************************************************/

using HCI_wireframe.Model.Doctor;
using HCI_wireframe.Model.Hospital;
using System;
using System.Collections.Generic;


namespace Class_diagram.Model.Hospital
{
   public class Medicine : Equipment
    {
        public List<ModelRoom> room { get; set; }

        public int doctorId { get; set; }
        public virtual DoctorUser doctor { get; set; }
        public String description { get; set; }
        public Boolean isConfirmed { get; set; }

        public Medicine(int id, String name, int quantity, string description, List<ModelRoom> room, DoctorUser doctor, Boolean isConfirmed) : base(id, name, quantity, room)
        {
            this.doctor = doctor;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }

        public Medicine(int id, String name, int quantity, string description, List<ModelRoom> room, int doctorId, Boolean isConfirmed) : base(id, name, quantity, room)
        {
            this.doctorId = doctorId;
            this.description = description;
            this.room = room;
            this.isConfirmed = isConfirmed;
        }
        public Medicine()
        {
        }
    }
}