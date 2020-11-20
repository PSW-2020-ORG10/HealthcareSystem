using FluentValidation;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(p => p.firstName).NotEmpty();
            RuleFor(p => p.secondName).NotEmpty();
            RuleFor(p => p.firstName).NotEmpty();
            RuleFor(p => p.medicalIdNumber).NotEmpty();
            RuleFor(p => p.dateOfBirth).NotEmpty();
            RuleFor(p => p.city).NotEmpty();
            RuleFor(p => p.bornIn).NotEmpty();
            RuleFor(p => p.parentName).NotEmpty();
            RuleFor(p => p.phoneNumber).NotEmpty();
            RuleFor(p => p.allergie).NotEmpty();
            RuleFor(p => p.uniqueCitizensidentityNumber).NotEmpty();
            RuleFor(p => p.email).Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"); 
            RuleFor(p => p.dateOfBirth).Matches(@"\b(((0?[469]|11)/(0?[1-9]|[12]\d|30)|(0?[13578]|1[02])/(0?[1-9]|[12]\d|3[01])|0?2/(0?[1-9]|1\d|2[0-8]))/([1-9]\d{3}|\d{2})|0?2/29/([1-9]\d)?([02468][048]|[13579][26]))\b");
        }
    }
}
