using FluentValidation;
using SearchMicroserviceApi.Dtos;

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
