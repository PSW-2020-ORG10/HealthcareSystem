using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Hospital
{
    public class ModelMedicine : StringData
    {
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public ModelMedicine(int id, string data, int roomId, Room room) : base(id, data)
        {
            RoomId = roomId;
            Room = room;
        }

        public ModelMedicine(int id, string data, int roomId) : base(id, data)
        {
            RoomId = roomId;
        }

        public ModelMedicine(string data) : base(data)
        {

        }

        public ModelMedicine() : base()
        {

        }
    }
}
