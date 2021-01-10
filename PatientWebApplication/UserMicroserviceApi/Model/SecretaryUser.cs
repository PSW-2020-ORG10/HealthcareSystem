/***********************************************************************
 * Module:  Secretary.cs
 * Author:  Luna
 * Purpose: Definition of the Class Secretary.Secretary
 ***********************************************************************/

using System;

namespace UserMicroserviceApi.Model
{
    public class SecretaryUser : EmployeeUser
    {
        public string Room { get; set; }

        public SecretaryUser(int id, string name, string secondname, string ucin, string date, string phone, string email, string pasword, string city,
            double salary, string room) :
            base(id, name, secondname, ucin, date, phone, email, pasword, city, salary)
        {
            Room = room;
        }

        public SecretaryUser() : base() {}

    }
}