using System.Collections.Generic;

namespace UserMicroserviceApi.Model
{
    public class ManagerUser : EmployeeUser
    {
        public virtual List<ManagerNotification> SpecialNotifications { get; set; }
        
        public ManagerUser() {}

        public ManagerUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
            double salary, List<ManagerNotification> specialNotifications) : base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            SpecialNotifications = specialNotifications;
        }

    }

}
