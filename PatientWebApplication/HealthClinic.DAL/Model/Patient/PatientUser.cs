/***********************************************************************
 * Module:  Patient.cs
 * Author:  Tamara
 * Purpose: Definition of the Class Patient.Patient
 ***********************************************************************/

using HealthClinic.CL.Model.Employee;
using System;
using System.Collections.Generic;

namespace HealthClinic.CL.Model.Patient
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

        public Boolean isVerified { get; set; }
        public String allergie { get; set; }
        public String city { get; set; }
        public Boolean guest { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean isRegisteredBySecretary { get; set; }
        public virtual List<ModelNotification> notifications { get; set; }
        public Boolean isMarried { get; set; }
        public String bornIn { get; set; }
        public String parentName { get; set; }
        public String exLastname { get; set; }
        public String gender { get; set; }
        public String file { get; set; }

        public Boolean isBlocked { get; set; }

        public PatientUser() : base()
        {

        }
       
        public PatientUser(int id, string name, string secondname, string gender, string ucin, String date, string phone, String medicalid, String allergie, String city, Boolean guest,
            String email, String password, Boolean isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            this.medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
            this.isBlocked = false;
        }
        public PatientUser(int id, string name, string secondname, string gender, string ucin, String date, string phone, String medicalid, String allergie, String city, Boolean guest,
            String email, String password, bool isMarried, string bornIn, string parentName, string file)
           : base(id, name, secondname, ucin, date, phone)
        {
            this.medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = "";
            this.file = file;
            this.isBlocked = false;
        }
      


        public PatientUser(string name, string secondname, string gender, string ucin, String date, string phone, String allergie, String city, Boolean guest,
             String email, String password, Boolean isRegisteredBySecretary, List<ModelNotification> notifications, bool isMarried, string bornIn, string parentName, string exLastname, string file)
            : base(name, secondname, ucin, date, phone)
        {
           
            this.gender = gender;
            isVerified = false;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
            this.isBlocked = false;
        }
        public PatientUser(string name, string secondname, string gender, string ucin, String date, string phone, String allergie, String city, Boolean guest,
           String email, String password, bool isMarried, string bornIn, string parentName, string file)
          : base(name, secondname, ucin, date, phone)
        {
            
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;
            this.city = city;
            this.guest = guest;
            this.email = email;
            this.password = password;
            this.isRegisteredBySecretary = isRegisteredBySecretary;
            this.notifications = notifications;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = "";
            this.file = file;
            this.isBlocked = false;
        }

        public PatientUser(PatientUser patient)
           : base(patient.id, patient.firstName, patient.secondName, patient.uniqueCitizensidentityNumber, patient.dateOfBirth, patient.phoneNumber)
        {
            this.medicalIdNumber = patient.medicalIdNumber;
            this.isVerified = true;
            this.allergie = patient.allergie;
            this.city = patient.city;
            this.guest = patient.guest;
            this.email = patient.email;
            this.password = patient.password;
            this.isRegisteredBySecretary = patient.isRegisteredBySecretary;
            this.notifications = patient.notifications;
            this.isMarried = patient.isMarried;
            this.bornIn = patient.bornIn;
            this.parentName = patient.parentName;
            this.exLastname = patient.exLastname;
            this.isBlocked = false;
        }
    }


    
}