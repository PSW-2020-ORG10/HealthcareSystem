using FluentValidation;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class RecommendedAppointmentValidator : AbstractValidator<RecommendedAppointmentDto>
    {
        public RecommendedAppointmentValidator()
        {
            RuleFor(f => f.DoctorId).NotNull();
            RuleFor(f => f.DoctorId > 0);
            RuleFor(f => f.Start).NotNull();
            RuleFor(f => f.Start).NotEmpty();
            RuleFor(f => f.Start).Matches(@"\b(((0?[469]|11)/(0?[1-9]|[12]\d|30)|(0?[13578]|1[02])/(0?[1-9]|[12]\d|3[01])|0?2/(0?[1-9]|1\d|2[0-8]))/([1-9]\d{3}|\d{2})|0?2/29/([1-9]\d)?([02468][048]|[13579][26]))\b");
            RuleFor(f => f.End).Matches(@"\b(((0?[469]|11)/(0?[1-9]|[12]\d|30)|(0?[13578]|1[02])/(0?[1-9]|[12]\d|3[01])|0?2/(0?[1-9]|1\d|2[0-8]))/([1-9]\d{3}|\d{2})|0?2/29/([1-9]\d)?([02468][048]|[13579][26]))\b");
            RuleFor(f => UtilityMethods.ParseDateInCorrectFormat(f.Start) >= DateTime.Now);
            RuleFor(f => UtilityMethods.ParseDateInCorrectFormat(f.End) >= DateTime.Now);
            RuleFor(f => UtilityMethods.ParseDateInCorrectFormat(f.Start) <= UtilityMethods.ParseDateInCorrectFormat(f.End));
            RuleFor(f => f.End).NotNull();
            RuleFor(f => f.End).NotEmpty();
            RuleFor(f => f.Priority).NotNull();
            RuleFor(f => f.Priority).NotEmpty();
        }
    }
}
