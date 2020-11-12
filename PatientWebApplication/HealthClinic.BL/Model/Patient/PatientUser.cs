/***********************************************************************
 * Module:  Patient.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Patient
 ***********************************************************************/

using HealthClinic.BL.Model.Employee;
using System;
using System.Collections.Generic;

namespace HealthClinic.BL.Model.Patient
{
    enum Priority
    {
        Doctor,
        Date,
        None
    }
   
   public  class PatientUser : User
    {
        public String medicalIdNumber { get; set; }
       
        public String allergie { get; set; }
        public String city { get; set; }
        public Boolean guest { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean isRegisteredBySecretary { get; set; }
        public virtual List<ModelNotification> notifications { get; set; }

        public PatientUser() : base()
        {

        }

        public PatientUser(int id, string name, string secondname, string ucin, String date, string phone, String medicalid, String allergie, String city, Boolean guest,
            String email, String password, Boolean isRegisteredBySecretary, List<ModelNotification> notifications)
           : base(id, name, secondname, ucin, date, phone)
        {
            this.medicalIdNumber = medicalid;
           
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
        }


    }
}