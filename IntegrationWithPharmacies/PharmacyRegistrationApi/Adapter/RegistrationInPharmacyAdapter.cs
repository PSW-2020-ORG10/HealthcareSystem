using PharmacyRegistrationApi.Dtos;
using PharmacyRegistrationApi.Model;

namespace PharmacyRegistrationApi.Adapters
{
    public class RegistrationInPharmacyAdapter
    {
        public static RegistrationInPharmacy RegistrationDtoToRegistration(RegistrationInPharmacyDto dto)
        {
            return new RegistrationInPharmacy(dto.PharmacyId, dto.ApiKey, dto.Name, dto.Town);
        }
    }
}
