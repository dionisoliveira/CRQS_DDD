using FluentValidation;
using DDDSample.Domain.Commands;

namespace DDDSample.Domain.Validation
{
    public class UserDeleteCommandValidation : AbstractValidator<UserDeleteCommand>
    {
        public UserDeleteCommandValidation()
        {
            RuleFor(c => c.Id)
              .NotEmpty().WithMessage("Invalid Id");

        }
    }
}
