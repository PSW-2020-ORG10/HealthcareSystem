namespace HealthClinic.BL.Model.Employee
{


    public class EmployeeUser : User
    {
        public double salary { get; set; }

        public string city { get; set; }

        public string email { get; set; }
        public string password { get; set; }
        public EmployeeUser() : base() { }


        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string password, string city,
            double salary) : base(id, name, secondname, ucin, date, phone)
        {
            this.email = email;
            this.password = password;
            this.city = city;

            this.salary = salary;
        }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword) : base(id, name, secondname, ucin, date, phone)
        {
            this.email = email;
            password = pasword;


        }



    }
}
