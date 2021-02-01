using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserMicroserviceApi.Model
{
    public class UserModel
    {
        public int Id { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }

        public UserModel(int id, string email, string password, string role)
        {
            Id = id;
            Email = email;
            Password = password;
            Role = role;
        }
    }
}
