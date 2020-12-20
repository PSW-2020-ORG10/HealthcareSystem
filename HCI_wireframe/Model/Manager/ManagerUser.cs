using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using HCI_wireframe.Model.Employee;
using HCI_wireframe.Model.Manager;

namespace Class_diagram.Model.Manager
{
    public class ManagerUser : EmployeeUser
    {
        public virtual List<ManagerNotification> specialNotifications { get; set; }
        public ManagerUser()
        {
        }

        public ManagerUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
            double salary, List<ManagerNotification> specialNotifications) : base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            this.specialNotifications = specialNotifications;
        }

    }
    
}
