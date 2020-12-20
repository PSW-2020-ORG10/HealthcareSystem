using Class_diagram.Model.Hospital;
using HCI_wireframe.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Hospital
{
    public class ModelRoom : StringData
    {
       

        public int EquipmentId { get; set; }
        public virtual Equipment Equipment { get; set; }

        public ModelRoom(int id, string data, int equipmentId, Equipment equipment) : base(id, data)
        {
            EquipmentId = equipmentId;
            Equipment = equipment;
        }

        public ModelRoom(int id, string data, int equipmentId) : base(id, data)
        {
            EquipmentId = equipmentId;
        }

        public ModelRoom(string data) : base(data)
        {
       
        }

        public ModelRoom() : base()
        {       

        }
    }
}
