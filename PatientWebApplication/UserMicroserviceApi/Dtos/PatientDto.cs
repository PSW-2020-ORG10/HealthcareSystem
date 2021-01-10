using UserMicroserviceApi.Model;

namespace UserMicroserviceApi.Dtos
{
    public class PatientDto : User
    {
        public string MedicalIdNumber { get; set; }
        public bool IsVerified { get; set; }
        public string Allergie { get; set; }
        public string City { get; set; }
        public bool Guest { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsMarried { get; set; }
        public string BornIn { get; set; }
        public string ParentName { get; set; }
        public string ExLastname { get; set; }
        public string File { get; set; }
        public string Gender { get; set; }

        public PatientDto() {}

        public PatientDto(string name, string secondname, string gender, string ucin, string date, string phone, string medicalIdNumber, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string exLastname, string file) : base(name, secondname, ucin, date, phone)
        {

            MedicalIdNumber = medicalIdNumber;
            Gender = gender;
            IsVerified = false;
            Allergie = allergie;
            City = city;
            Email = email;
            Password = password;
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = exLastname;
            File = file;
        }

        public PatientDto(string name, string secondname, string gender, string ucin, string date, string phone, string medicalIdNumber, string allergie, string city, string email, string password, bool isMarried, string bornIn, string parentName, string file) : base(name, secondname, ucin, date, phone)
        {
            MedicalIdNumber = medicalIdNumber;
            IsVerified = false;
            Gender = gender;
            Allergie = allergie;
            City = city;
            Email = email;
            Password = password;
            IsMarried = isMarried;
            BornIn = bornIn;
            ParentName = parentName;
            ExLastname = "";
            File = file;
        }
    }
}
