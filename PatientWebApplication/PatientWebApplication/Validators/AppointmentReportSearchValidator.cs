using FluentValidation;
using HealthClinic.CL.Dtos;
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
            var date = new DateTime();
            When(f => !f.Start.Equals(""), () =>
            {
                RuleFor(f => DateTime.TryParseExact(f.Start, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)).Equal(true);
            });
            When(f => !f.End.Equals(""), () => {
                RuleFor(f => DateTime.TryParseExact(f.End, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date)).Equal(true);
            });
        }
    }
}
