using FluentValidation;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Domain.Validator.Users;

public class PasswordValidator : AbstractValidator<Password>
{
    public PasswordValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty().NotNull()
            .WithMessage("O campo Id é obrigatório.");

        RuleFor(p => p.PasswordSize)
            .NotNull().NotEmpty().GreaterThan(8)
            .WithMessage("A senha deve ter mais de 8 dígitos");

        RuleFor(p => p.ComplexedSize)
            .GreaterThanOrEqualTo(12)
            .WithMessage(p => $"A senha deve ter uma complexidade mínima de 12 pontos, atualmente ela tem uma complexidade de {p.ComplexedSize}");

    }

}
