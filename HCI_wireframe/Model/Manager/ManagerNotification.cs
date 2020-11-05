using Class_diagram.Model.Manager;
using HCI_wireframe.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Manager
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
