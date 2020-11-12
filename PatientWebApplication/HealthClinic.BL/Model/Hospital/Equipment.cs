/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Model.Hospital
{
    public class Equipment : Entity
    {
        public virtual List<ModelRoom> room { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public Equipment()
        {
        }
        public Equipment(int id, string name, int quantity) : base(id)
        {

            this.name = name;
            this.quantity = quantity;
        }
        public Equipment(int id, string name, int quantity, List<ModelRoom> room) : base(id)
        {

            this.name = name;
            this.quantity = quantity;
            this.room = room;
        }



    }
}