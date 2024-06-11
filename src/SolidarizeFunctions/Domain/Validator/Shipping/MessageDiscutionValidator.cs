using FluentValidation;

namespace Solidarize.Domain.Validator.Shipping;

public class MessageDiscutionValidator: AbstractValidator<Models.Shipping.MessageDiscution>
{
    public MessageDiscutionValidator()
    {
        RuleFor(s => s.Message)
        .NotEmpty().WithMessage("A mensagem do comentario é obrigatória.")
        .MinimumLength(8).WithMessage("A mensagem do comentario deve ter pelo menos 8 caracteres.");

        RuleFor(s => s.Id)
        .NotEmpty().WithMessage("O Id do comentario é obrigatório.");

        RuleFor(s => s.IdShipping)
        .NotEmpty().WithMessage("O IdShipping do comentario é obrigatório.");

        RuleFor(s => s.IdUser)
        .NotNull()
        .NotEmpty().WithMessage("O IdUser do comentario é obrigatório.");
    }
    
}
