/***********************************************************************
 * Module:  Room.cs
 * Author:  Lenovo
 * Purpose: Definition of the Class Manager.Room
 ***********************************************************************/

using System.Collections.Generic;

namespace SearchMicroserviceApi.Model
{
    public class Room : Entity
    {
        public string TypeOfRoom { get; set; }
        public virtual List<ModelEquipment> Equipment { get; set; }
        public virtual List<ModelMedicine> Medicine { get; set; }
        public bool ForUse { get; set; }

        public Room(int id, string typeOfRoom, bool forUse) : base(id)
        {
            TypeOfRoom = typeOfRoom;
            ForUse = forUse;
        }

        public Room(int id, string typeOfRoom, List<ModelEquipment> equipment, List<ModelMedicine> medicine, bool forUse) : base(id)
        {
            TypeOfRoom = typeOfRoom;
            Equipment = equipment;
            Medicine = medicine;
            ForUse = forUse;
        }

        public Room() : base() { }
    }
}