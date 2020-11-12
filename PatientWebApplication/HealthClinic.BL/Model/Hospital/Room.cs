/***********************************************************************
 * Module:  Room.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using HealthClinic.BL.Model.Patient;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Model.Hospital
{
    public class Room : Entity
    {
        public string typeOfRoom { get; set; }

        public virtual List<ModelEquipment> equipment { get; set; }
        public virtual List<ModelMedicine> medicine { get; set; }
        public bool forUse { get; set; }


        public Room(int id, string typeOfRoom, bool forUse) : base(id)
        {

            this.typeOfRoom = typeOfRoom;
            this.forUse = forUse;

        }


        public Room(int id, string typeOfRoom, List<ModelEquipment> equipment, List<ModelMedicine> medicine, bool forUse) : base(id)
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