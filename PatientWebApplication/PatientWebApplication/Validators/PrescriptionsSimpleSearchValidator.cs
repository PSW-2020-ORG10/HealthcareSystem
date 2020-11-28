using FluentValidation;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class PrescriptionsSimpleSearchValidator : AbstractValidator<PrescriptionSearchDto>
    {
        public PrescriptionsSimpleSearchValidator()
        {
            RuleFor(f => f.Medicines).NotNull();
            RuleFor(f => f.Comment).NotNull();
            RuleFor(f => f.Doctor).NotNull();
            RuleFor(f => f.IsUsed).NotNull();
        }
    }
}
