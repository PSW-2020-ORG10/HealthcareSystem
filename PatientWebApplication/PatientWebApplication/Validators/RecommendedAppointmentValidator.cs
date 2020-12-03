﻿using FluentValidation;
using HealthClinic.CL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientWebApplication.Validators
{
    public class RecommendedAppointmentValidator : AbstractValidator<RecommendedAppointmentDto>
    {
        public RecommendedAppointmentValidator()
        {
            RuleFor(f => f.DoctorId).NotNull();
            RuleFor(f => f.DoctorId > 0);
            RuleFor(f => f.Start).NotNull();
            RuleFor(f => f.Start).NotEmpty();
            RuleFor(f => f.End).NotNull();
            RuleFor(f => f.End).NotEmpty();
            RuleFor(f => f.Priority).NotNull();
            RuleFor(f => f.Priority).NotEmpty();
        }
    }
}
