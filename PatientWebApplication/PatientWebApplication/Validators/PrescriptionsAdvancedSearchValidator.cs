using FluentValidation;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class PrescriptionsAdvancedSearchValidator : AbstractValidator<PrescriptionAdvancedSearchDto>
    {
        public PrescriptionsAdvancedSearchValidator()
        {
            RuleFor(f => f.FirstRole).NotNull();
            RuleFor(f => f.First).NotNull();
            RuleFor(f => f.RestRoles).NotNull();
            RuleFor(f => f.Rest).NotNull();
            RuleFor(f => f.LogicOperators).NotNull();
            RuleFor(f => f.LogicOperators.Length == f.RestRoles.Length);
            RuleFor(f => f.Rest.Length == f.RestRoles.Length);
        }
    }
}
