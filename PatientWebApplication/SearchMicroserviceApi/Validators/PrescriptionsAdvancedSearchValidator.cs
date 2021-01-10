using FluentValidation;
using SearchMicroserviceApi.Dtos;
using System.Linq;

namespace SearchMicroserviceApi.Validators
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
