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
       
        

        public String TypeOfRoom { get; set; }

        public List<String> equipment { get; set; }
        public List<String> medicine { get; set; }
        public Boolean forUse { get; set; }

       
        public Room(int ID, String type, Boolean forUse) : base(ID)
        {
           
            this.TypeOfRoom = type;
            this.forUse = forUse;

        }


        public Room(int ID, String type, List<String> eqp,List<String> med, Boolean forUse) : base(ID)
        {
            this.TypeOfRoom = type;
            this.equipment = eqp;
            this.medicine = med;
            this.forUse = forUse;
        }


        public Room() : base()
        {
      
        }

    }
}