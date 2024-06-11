using FluentValidation;

namespace Solidarize.Domain.Validator.Shipping;

public class ShippingValidator : AbstractValidator<Models.Shipping.Shipping>
{
    public ShippingValidator()
    {
        RuleFor(s => s.Name)
        .NotEmpty().WithMessage("O nome da doação é obrigatório.")
        .MinimumLength(8).WithMessage("O nome da doação deve ter pelo menos 8 caracteres.");

        RuleFor(s => s.Description)
        .NotEmpty().WithMessage("A descrição da doação é obrigatória.")
        .MinimumLength(8).WithMessage("A descrição da doação deve ter pelo menos 8 caracteres.");

        RuleFor(s => s.Id)
        .NotEmpty().WithMessage("O Id da doação é obrigatório.");

        RuleFor(s => s.CreationDate)
        .NotEmpty().WithMessage("A data de criação é obrigatória.");

        RuleFor(s => s.IdUserCreation)
        .NotEmpty().WithMessage("O IdUserCreation da doação é obrigatório.");

        RuleFor(s => s.IdUserResponse)
        .NotEmpty().WithMessage("O IdUserResponse da doação é obrigatório.");
    }
}
