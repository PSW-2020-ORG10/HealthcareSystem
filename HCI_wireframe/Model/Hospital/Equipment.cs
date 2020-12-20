/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Hospital;
using System;
using System.Collections.Generic;

namespace Class_diagram.Model.Hospital
{
   public class Equipment : Entity
   {
      public virtual List<ModelRoom> room { get; set; }
        public String name { get; set; }
        public int quantity { get; set; }
        public Equipment()
        {
        }
        public Equipment(int id, String name, int quantity): base(id) {
            
            this.name = name;
            this.quantity = quantity;
        }
        public Equipment(int id, String name, int quantity, List<ModelRoom> room) : base(id)
        {

            this.name = name;
            this.quantity = quantity;
            this.room = room;
        }
     

  
    }
}