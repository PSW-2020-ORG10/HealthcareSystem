/***********************************************************************
 * Module:  Patient.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Patient
 ***********************************************************************/

using Class_diagram.Model.Doctor;
using Class_diagram.Model.Employee;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Class_diagram.Model.Patient
{enum Priority
    {
        Doctor,
        Date,
        None
    }
   
   public  class PatientUser : User
    {
        public String MedicalIDnumber { get; set; }
       
        public String Allergie { get; set; }
        public String City { get; set; }
        public Boolean guest { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public Boolean RegisteredBySecretary { get; set; }
        public List<String> Notifications { get; set; }

        public PatientUser() : base()
        {

        }

        public PatientUser(int id, string name, string secondname, string ucin, String date, string phone, String medicalId, String allergie, String city, Boolean isGuest,
            String email, String password, Boolean registredBySec, List<String>notifications)
           : base(id, name, secondname, ucin, date, phone)
        {
            this.MedicalIDnumber = medicalId;
           
            this.Allergie = allergie;
            this.City = city;
            this.guest = isGuest;
            this.Email = email;
            this.Password = password;
            this.RegisteredBySecretary = registredBySec;
            this.Notifications = notifications;
        }


    }
}