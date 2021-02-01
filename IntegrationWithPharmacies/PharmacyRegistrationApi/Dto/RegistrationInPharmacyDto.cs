using PharmacyRegistrationApi.Model;
using System;

namespace PharmacyRegistrationApi.Dtos
{
    public class RegistrationInPharmacyDto
    {
        public int PharmacyId { get; set; }
        public String Town { get; set; }
        public PharmacyConnectionInfo PharmacyConnectionInfo { get; set; }
        public virtual PharmacyNameInfo PharmacyNameInfo { get; set; }


        public RegistrationInPharmacyDto(){ }
      
        public RegistrationInPharmacyDto(int pharmacyId,  String town, PharmacyConnectionInfo pharmacyConnectionInfo, PharmacyNameInfo pharmacyNameInfo)
        {
            PharmacyId = pharmacyId;
            Town = town;
            PharmacyConnectionInfo = pharmacyConnectionInfo;
            pharmacyNameInfo = pharmacyNameInfo;
        }
        public RegistrationInPharmacyDto(int pharmacyId,  String town)
        {
            PharmacyId = pharmacyId;
            Town = town;
        }
      
    }
}
