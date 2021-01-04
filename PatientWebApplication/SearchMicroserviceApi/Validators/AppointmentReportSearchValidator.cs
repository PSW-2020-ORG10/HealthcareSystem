using FluentValidation;
using SearchMicroserviceApi.Dtos;
using SearchMicroserviceApi.Utility;

namespace SearchMicroserviceApi.Validators
{
    public class AppointmentReportSearchValidator : AbstractValidator<AppointmentReportSearchDto>
    {
        public AppointmentReportSearchValidator()
        {
            When(f => !UtilityMethods.CheckIfStringIsEmpty(f.Start), () =>
            {
                RuleFor(f => UtilityMethods.TryParseDateInCorrectFormat(f.Start)).Equal(true);
            });
            When(f => !UtilityMethods.CheckIfStringIsEmpty(f.End), () =>
            {
                RuleFor(f => UtilityMethods.TryParseDateInCorrectFormat(f.End)).Equal(true);
            });
        }
    }
}
