using System;
using System.Collections.Generic;
using HCI_wireframe.Model.Employee;

namespace Class_diagram.Model.Manager
{
    public class ManagerUser : EmployeeUser
    {
        public List<String> specialNotifications { get; set; }
        public ManagerUser()
        {
        }

        public ManagerUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
            double salary, List<String> spec) : base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            this.specialNotifications = spec;
        }

    }
    
}
