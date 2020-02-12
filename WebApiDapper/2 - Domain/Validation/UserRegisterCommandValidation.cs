using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDSample.Domain.Command;

namespace DDDSample.Domain.Validation
{
    public class UserRegisterCommandValidation : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name Required")
                .Length(2, 150).WithMessage("Invalid Name");
        }
    }
}
