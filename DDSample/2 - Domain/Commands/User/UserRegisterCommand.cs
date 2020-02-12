using FluentValidation.Results;
using System;
using DDDSample.Domain.Commands;
using DDDSample.Domain.Validation;

namespace DDDSample.Domain.Command
{
    public class UserRegisterCommand : UserRegister
    {
        public DateTime BirthDate { get; set; }

        public UserRegisterCommand( string name, DateTime birthDate)
        {
            Name = name;
           // Id = id;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new UserRegisterCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
