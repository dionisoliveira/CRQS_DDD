using DDDSample.Domain.Validation;

namespace DDDSample.Domain.Commands
{
    public class UserDeleteCommand : UserRegister
    {

        public UserDeleteCommand(int id)
        {
            Id = id;

        }

        public override bool IsValid()
        {
            var validate = new UserDeleteCommandValidation().Validate(this);
            return validate.IsValid;
        }
    }
}
