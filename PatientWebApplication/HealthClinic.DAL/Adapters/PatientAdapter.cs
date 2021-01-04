using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class PatientAdapter
    {
        public static PatientUser PatientDtoToPatient(PatientDto dto)
        {
            return new PatientUser(dto.id, dto.firstName, dto.secondName, dto.gender, dto.uniqueCitizensidentityNumber, dto.dateOfBirth, dto.phoneNumber, dto.medicalIdNumber, dto.allergie, dto.city, dto.guest, dto.email, dto.password, false, new List<ModelNotification>(), dto.isMarried, dto.bornIn, dto.parentName, dto.exLastname, dto.file);
        }
    }
}
