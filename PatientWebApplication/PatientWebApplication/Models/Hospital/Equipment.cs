/***********************************************************************
 * Module:  Equipment.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Equipment
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;

namespace Class_diagram.Model.Hospital
{
   public class Equipment : Entity
   {
      public List<String> room { get; set; }
        public String Name { get; set; }
        public int Quantity { get; set; }

        public Equipment(int id, String name, int quantity): base(id) {
            
            this.Name = name;
            this.Quantity = quantity;
        }
        public Equipment(int id, String name, int quantity, List<String> r) : base(id)
        {

            this.Name = name;
            this.Quantity = quantity;
            this.room = r;
        }
        public Equipment()
        {
        }

  
    }
}