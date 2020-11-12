using HealthClinic.CL.Model.Patient;

namespace HealthClinic.CL.Model.Hospital
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
