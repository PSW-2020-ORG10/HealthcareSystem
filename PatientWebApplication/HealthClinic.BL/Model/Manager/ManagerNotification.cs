using HealthClinic.BL.Model.Patient;

namespace HealthClinic.BL.Model.Manager
{
    public class ManagerNotification : StringData
    {
        public int ManagerUserId { get; set; }
        public virtual ManagerUser ManagerUser { get; set; }

        public ManagerNotification(int id, string data, int managerUserId, ManagerUser managerUser) : base(id, data)
        {
            ManagerUserId = managerUserId;
            ManagerUser = managerUser;
        }

        public ManagerNotification(int id, string data, int managerUserId) : base(id, data)
        {
            ManagerUserId = managerUserId;
        }

        public ManagerNotification(string data) : base(data)
        {

        }

        public ManagerNotification() : base()
        {

        }
    }
}
