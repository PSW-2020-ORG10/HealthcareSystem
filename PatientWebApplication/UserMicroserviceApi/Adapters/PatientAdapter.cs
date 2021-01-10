using System.Collections.Generic;
using UserMicroserviceApi.Model;
using PatientDto = UserMicroserviceApi.Dtos.PatientDto;

namespace UserMicroserviceApi.Adapters
{
    public class PatientAdapter
    {
        public static PatientUser PatientDtoToPatient(PatientDto dto)
        {
            return new PatientUser(dto.Id, dto.FirstName, dto.SecondName, dto.Gender, dto.UniqueCitizensidentityNumber, dto.DateOfBirth, dto.PhoneNumber, dto.MedicalIdNumber, dto.Allergie, dto.City, dto.Guest, dto.Email, dto.Password, false, new List<ModelNotification>(), dto.IsMarried, dto.BornIn, dto.ParentName, dto.ExLastname, dto.File);
        }
    }
}
