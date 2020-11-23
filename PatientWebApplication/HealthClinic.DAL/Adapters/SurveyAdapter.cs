using HealthClinic.CL.Dtos;
using HealthClinic.CL.Model.Patient;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthClinic.CL.Adapters
{
    public class SurveyAdapter
    {
        public static Survey SurveyDtoToSurvey(SurveyDto dto)
        {
            return new Survey(dto.patientId, dto.doctorId, dto.doctorsProfessionalism, dto.doctorsPoliteness, dto.doctorsTechnicality, dto.doctorsSkill, dto.doctorsKnowledge, dto.doctorsWorkingPace, dto.medicalStaffsProfessionalism, dto.doctorsPoliteness, dto.doctorsTechnicality, dto.medicalStaffsSkill, dto.medicalStaffsKnowledge, dto.medicalStaffsWorkingPace, dto.hospitalEnvironment, dto.hospitalEquipment, dto.hospitalHygiene, dto.hospitalPrices, dto.hospitalWaitingTime);
        }
    }
}
