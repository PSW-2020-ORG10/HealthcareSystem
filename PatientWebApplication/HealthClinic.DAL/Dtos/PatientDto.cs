using HealthClinic.CL.Model.Employee;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Dtos
{
    public class PatientDto : User
    {

        public String medicalIdNumber { get; set; }
        public Boolean isVerified { get; set; }
        public String allergie { get; set; }
        public String city { get; set; }
        public Boolean guest { get; set; }
        public String email { get; set; }
        public String password { get; set; }        
        public Boolean isMarried { get; set; }
        public String bornIn { get; set; }
        public String parentName { get; set; }
        public String exLastname { get; set; }
        public String file { get; set; }
        public String gender { get; set; }

        public PatientDto()
        {   
        }

        public PatientDto(string name, string secondname, string gender, string ucin, String date, string phone, String medicalid, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string exLastname,string file) : base(name, secondname, ucin, date, phone)
        {

            this.medicalIdNumber = medicalid;
            this.gender = gender;
            isVerified = false;
            this.allergie = allergie;
            this.city = city;
            this.email = email;
            this.password = password;          
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            this.exLastname = exLastname;
            this.file = file;
        }

        public PatientDto(string name, string secondname, string gender, string ucin, String date, string phone, String medicalid, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string file) : base(name, secondname, ucin, date, phone)
        {
            this.medicalIdNumber = medicalid;
            isVerified = false;
            this.gender = gender;
            this.allergie = allergie;           
            this.city = city;           
            this.email = email;
            this.password = password;
            this.isMarried = isMarried;
            this.bornIn = bornIn;
            this.parentName = parentName;
            exLastname = "";
            this.file = file;

        }
    }
}
