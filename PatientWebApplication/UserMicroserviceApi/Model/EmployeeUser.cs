namespace UserMicroserviceApi.Model
{
    public class EmployeeUser : User
    {
        public double Salary { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public EmployeeUser() : base() { }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string password, string city,
            double salary) : base(id, name, secondname, ucin, date, phone)
        {
            Email = email;
            Password = password;
            City = city;
            Salary = salary;
        }

        public EmployeeUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string password) : base(id, name, secondname, ucin, date, phone)
        {
            Email = email;
            Password = password;
        }
    }
}
