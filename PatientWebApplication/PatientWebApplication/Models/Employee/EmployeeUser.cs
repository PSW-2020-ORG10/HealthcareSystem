using Class_diagram.Model.Employee;
using Class_diagram.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_wireframe.Model.Employee
{

   
     public class EmployeeUser : User
    {
        public Double salary { get; set; }
       
        public String city { get; set; }

        public String Email { get; set; }
        public String Password { get; set; }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, String city,
            Double salary) : base(id, name, secondname, ucin, date, phone)
        {
            this.Email = email;
            this.Password = pasword;
            this.city = city;
          
            this.salary = salary;
        }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword) : base(id, name, secondname, ucin, date, phone)
        {
            this.Email = email;
            this.Password = pasword;
           
         
        }

        public EmployeeUser() : base()
        {

        }
       
    }
}
