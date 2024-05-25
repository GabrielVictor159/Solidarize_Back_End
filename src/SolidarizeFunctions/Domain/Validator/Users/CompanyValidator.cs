using FluentValidation;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Domain.Validator.Users;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
        RuleFor(company => company.CompanyName)
        .NotEmpty().WithMessage("O nome da empresa é obrigatório.")
        .MinimumLength(4).WithMessage("O nome da empresa deve ter pelo menos 4 caracteres.");

        RuleFor(company => company.Description).NotEmpty().WithMessage("A descrição é obrigatória.");

        RuleFor(company => company.LegalNature).NotNull().WithMessage("A natureza jurídica é obrigatória.");

        RuleFor(company => company.LocationX).NotEmpty().Matches(@"^-?\d+(\.\d+)?$").WithMessage("A localização X deve ser um número válido.");

        RuleFor(company => company.LocationY).NotEmpty().Matches(@"^-?\d+(\.\d+)?$").WithMessage("A localização Y deve ser um número válido.");

        RuleFor(company => company.Cnpj)
            .NotEmpty().WithMessage("O CNPJ é obrigatório.")
            .Must(ValidarCNPJ).WithMessage("O CNPJ é inválido.");

        RuleFor(company => company.Address).NotEmpty().WithMessage("O endereço é obrigatório.");

        RuleFor(company => company.Telefone).NotEmpty().Matches(@"^\(\d{2}\)\s\d{4,5}-\d{4}$").WithMessage("O telefone deve seguir o padrão (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.");

        RuleFor(company => company.Email).NotEmpty().EmailAddress().WithMessage("O e-mail deve ser um endereço de e-mail válido.");

        RuleFor(company => company.Id).NotEmpty().WithMessage("O ID é obrigatório.");

        RuleFor(company => company.Idpassword).NotEmpty().WithMessage("O ID da senha é obrigatório.");
    }
    private bool ValidarCNPJ(string cnpj)
    {
        int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

        cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        if (cnpj.Length != 14)
            return false;

        string tempCnpj = cnpj.Substring(0, 12);
        int soma = 0;
        int resto = 0;

        for (int i = 0; i < 12; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        if (resto != int.Parse(cnpj[12].ToString()))
            return false;

        soma = 0;
        tempCnpj = cnpj.Substring(0, 13);
        for (int i = 0; i < 13; i++)
            soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

        resto = (soma % 11);
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        return resto == int.Parse(cnpj[13].ToString());
    }
}
