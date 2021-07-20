using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using SoftMediaClubTestTask.API.Models;

namespace SoftMediaClubTestTask.API.CustomValidationRules
{
    public class AcademicPerformanceTypeValidator : AbstractValidator<AcademicPerformanceType>
    {
        public AcademicPerformanceTypeValidator()
        {
            RuleFor(x => x.Code).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
