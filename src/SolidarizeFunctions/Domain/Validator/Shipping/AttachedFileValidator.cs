using FluentValidation;

namespace Solidarize.Domain.Validator.Shipping;

public class AttachedFileValidator: AbstractValidator<Models.Shipping.AttachedFile>
{
    public AttachedFileValidator()
    {
        RuleFor(s => s.Item)
        .NotEmpty().WithMessage("O conteudo do item do attached file é obrigatório.");

        RuleFor(s => s.Id)
        .NotEmpty().WithMessage("O Id do attached attached file é obrigatório.");

        RuleFor(s => s.IdMessageDiscution)
        .NotEmpty().WithMessage("O Id da mensagem do attached file é obrigatório.");

        RuleFor(s => s.Type)
        .NotNull().WithMessage("O type do attached file é obrigatório.");

        RuleFor(s => s.CreationDate)
        .NotEmpty().WithMessage("A data de criação do attached file é obrigatório.");
    }
}
