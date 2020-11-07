using Class_diagram.Model.Patient;
using FluentValidation;
using PatientWebApplication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class FeedbackValidator : AbstractValidator<FeedbackDto>
    {
        public FeedbackValidator()
        {
            RuleFor(f => f.Message).NotEmpty();
        }
    }
}
