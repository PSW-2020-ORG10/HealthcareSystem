using System;

namespace EPrescriptionApi.Model
{
    public class RegistrationInPharmacy : Entity
    {
        public int PharmacyId { get; set; }
        public String Town { get; set; }
        public virtual PharmacyConnectionInfo PharmacyConnectionInfo { get; set; }
        public virtual PharmacyNameInfo PharmacyNameInfo { get; set; }

        public RegistrationInPharmacy() : base() { }

        public RegistrationInPharmacy(int id, int pharmacyId, String town, PharmacyConnectionInfo pharmacyConnectionInfo, PharmacyNameInfo pharmacyNameInfo) : base(id)
        {
            PharmacyId = pharmacyId;
            Town = town;
            PharmacyConnectionInfo = pharmacyConnectionInfo;
            PharmacyNameInfo = pharmacyNameInfo;
        }
    }
}
