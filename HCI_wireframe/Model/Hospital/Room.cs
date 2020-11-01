/***********************************************************************
 * Module:  Room.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Class_diagram.Model.Hospital
{
   public class Room : Entity
   {
        public String typeOfRoom { get; set; }

        public List<String> equipment { get; set; }
        public List<String> medicine { get; set; }
        public Boolean forUse { get; set; }

       
        public Room(int id, String typeOfRoom, Boolean forUse) : base(id)
        {
           
            this.typeOfRoom = typeOfRoom;
            this.forUse = forUse;

        }


        public Room(int id, String typeOfRoom, List<String> equipment, List<String> medicine, Boolean forUse) : base(id)
        {
            this.typeOfRoom = typeOfRoom;
            this.equipment = equipment;
            this.medicine = medicine;
            this.forUse = forUse;
        }


        public Room() : base()
        {
      
        }

    }
}