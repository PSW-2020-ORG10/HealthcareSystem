using FeedbackMicroserviceApi.Dtos;
using FluentValidation;

namespace PatientWebApplication.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbackDto>
    {
        public FeedbackValidator()
        {
            RuleFor(f => f.Message).NotEmpty();
            RuleFor(f => f.PatientId >= 0);
        }
    }
}