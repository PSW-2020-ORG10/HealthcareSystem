/***********************************************************************
 * Module:  Room.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Hospital;
using System;
using System.Collections.Generic;
using System.Windows.Documents;

namespace Class_diagram.Model.Hospital
{
   public class Room : Entity
   {
        public String typeOfRoom { get; set; }

        public virtual List<ModelEquipment> equipment { get; set; }
        public virtual List<ModelMedicine> medicine { get; set; }
        public Boolean forUse { get; set; }

       
        public Room(int id, String typeOfRoom, Boolean forUse) : base(id)
        {
           
            this.typeOfRoom = typeOfRoom;
            this.forUse = forUse;

        }


        public Room(int id, String typeOfRoom, List<ModelEquipment> equipment, List<ModelMedicine> medicine, Boolean forUse) : base(id)
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