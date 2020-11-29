using FluentValidation;
using HealthClinic.CL.Dtos;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class AppointmentReportSearchValidator : AbstractValidator<AppointmentReportSearchDto>
    {
        public AppointmentReportSearchValidator()
        {
            When(f => !UtilityMethods.CheckIfStringIsEmpty(f.Start), () =>
            {
                RuleFor(f => UtilityMethods.TryParseDateInCorrectFormat(f.Start)).Equal(true);
            });
            When(f => !UtilityMethods.CheckIfStringIsEmpty(f.End), () => {
                RuleFor(f => UtilityMethods.TryParseDateInCorrectFormat(f.End)).Equal(true);
            });
        }
    }
}
