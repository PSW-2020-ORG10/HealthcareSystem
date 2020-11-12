using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Hospital
{
    public class ModelEquipment : StringData
    {
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }

        public ModelEquipment(int id, string data, int roomId, Room room) : base(id, data)
        {
            RoomId = roomId;
            Room = room;
        }

        public ModelEquipment(int id, string data, int roomId) : base(id, data)
        {
            RoomId = roomId;
        }

        public ModelEquipment(string data) : base(data)
        {

        }

        public ModelEquipment() : base()
        {

        }
    }
}
