using FluentValidation;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Domain.Validator.Users;

public class PasswordValidator: AbstractValidator<Password>
    {
        public PasswordValidator()
        {
            RuleFor(p=>p.Id)
            .NotEmpty().NotNull()
            .WithMessage("The Id field is required.");

            RuleFor(p=>p.PasswordSize)
            .NotNull().NotEmpty().GreaterThan(8)
            .WithMessage("Password must be longer than 8 digits");

            RuleFor(p=>p.ComplexedSize)
            .GreaterThanOrEqualTo(12)
            .WithMessage(p=>$"The password must have a minimum complexity of 12 points, currently it has a complexity of {p.ComplexedSize}");

            
        }
        
    }
