using System;
using System.ComponentModel.DataAnnotations;

namespace UrgentMedicineOrderApi.Model
{
    public class PharmacyNameInfo
    {
        [Key]
        public String Name { get; set; }
        public int RegistrationInPharmacyId { get; set; }

        public PharmacyNameInfo() { }
        public PharmacyNameInfo(String name)
        {
            Name = name;
        }
  
        public PharmacyNameInfo(String name, int registrationInPharmacyId)
        {
            Name = name;
            RegistrationInPharmacyId = registrationInPharmacyId;
        }
    }
}
