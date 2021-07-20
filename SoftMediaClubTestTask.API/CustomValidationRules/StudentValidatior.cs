using FluentValidation;
using SoftMediaClubTestTask.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftMediaClubTestTask.API.CustomValidationRules
{
    public class StudentValidatior : AbstractValidator<Student>
    {
        public StudentValidatior()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
        }
    }
}
