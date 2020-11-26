using FluentValidation;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class SurveyValidator : AbstractValidator<SurveyDto>
    {
        public SurveyValidator()
        {
            RuleFor(p => p.doctorsKnowledge).NotEmpty();
            RuleFor(p => p.doctorsPoliteness).NotEmpty();
            RuleFor(p => p.doctorsProfessionalism).NotEmpty();
            RuleFor(p => p.doctorsSkill).NotEmpty();
            RuleFor(p => p.doctorsTechnicality).NotEmpty();
            RuleFor(p => p.doctorsWorkingPace).NotEmpty();
            RuleFor(p => p.medicalStaffsKnowledge).NotEmpty();
            RuleFor(p => p.medicalStaffsPoliteness).NotEmpty();
            RuleFor(p => p.medicalStaffsProfessionalism).NotEmpty();
            RuleFor(p => p.medicalStaffsSkill).NotEmpty();
            RuleFor(p => p.medicalStaffsTechnicality).NotEmpty();
            RuleFor(p => p.medicalStaffsWorkingPace).NotEmpty();
            RuleFor(p => p.hospitalEnvironment).NotEmpty();
            RuleFor(p => p.hospitalEquipment).NotEmpty();
            RuleFor(p => p.hospitalHygiene).NotEmpty();
            RuleFor(p => p.hospitalPrices).NotEmpty();
            RuleFor(p => p.hospitalWaitingTime).NotEmpty();
            
            RuleFor(p => p.doctorsKnowledge >= 1);
            RuleFor(p => p.doctorsPoliteness >= 1);
            RuleFor(p => p.doctorsProfessionalism >= 1);
            RuleFor(p => p.doctorsSkill >= 1);
            RuleFor(p => p.doctorsTechnicality >= 1);
            RuleFor(p => p.doctorsWorkingPace >= 1);
            RuleFor(p => p.medicalStaffsKnowledge >= 1);
            RuleFor(p => p.medicalStaffsPoliteness >= 1);
            RuleFor(p => p.medicalStaffsProfessionalism >= 1);
            RuleFor(p => p.medicalStaffsSkill >= 1);
            RuleFor(p => p.medicalStaffsTechnicality >= 1);
            RuleFor(p => p.medicalStaffsWorkingPace >= 1);
            RuleFor(p => p.hospitalEnvironment >= 1);
            RuleFor(p => p.hospitalEquipment >= 1);
            RuleFor(p => p.hospitalHygiene >= 1);
            RuleFor(p => p.hospitalPrices >= 1);
            RuleFor(p => p.hospitalWaitingTime >= 1);

            RuleFor(p => p.doctorsKnowledge <= 5);
            RuleFor(p => p.doctorsPoliteness <= 5);
            RuleFor(p => p.doctorsProfessionalism <= 5);
            RuleFor(p => p.doctorsSkill <= 5);
            RuleFor(p => p.doctorsTechnicality <= 5);
            RuleFor(p => p.doctorsWorkingPace <= 5);
            RuleFor(p => p.medicalStaffsKnowledge <= 5);
            RuleFor(p => p.medicalStaffsPoliteness <= 5);
            RuleFor(p => p.medicalStaffsProfessionalism <= 5);
            RuleFor(p => p.medicalStaffsSkill <= 5);
            RuleFor(p => p.medicalStaffsTechnicality <= 5);
            RuleFor(p => p.medicalStaffsWorkingPace <= 5);
            RuleFor(p => p.hospitalEnvironment <= 5);
            RuleFor(p => p.hospitalEquipment <= 5);
            RuleFor(p => p.hospitalHygiene <= 5);
            RuleFor(p => p.hospitalPrices <= 5);
            RuleFor(p => p.hospitalWaitingTime <= 5);
        }

    }
}
