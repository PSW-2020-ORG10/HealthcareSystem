using FluentValidation;
using HealthClinic.CL.Model.Patient;
using HealthClinic.CL.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class AppointmentValidator : AbstractValidator<DoctorAppointment>
    {
        public AppointmentValidator()
        {
            RuleFor(a => a.id).Equal(0);
            RuleFor(a => a.DoctorUserId).GreaterThan(0);
            RuleFor(a => a.PatientUserId).GreaterThan(0);
            RuleFor(a => UtilityMethods.TryParseDateInCorrectFormat(a.Date)).Equal(true);
            RuleFor(a => a.Doctor).Null();
            RuleFor(a => a.Patient).Null();
            RuleFor(a => a.referral).Empty();
        }
    }
}
