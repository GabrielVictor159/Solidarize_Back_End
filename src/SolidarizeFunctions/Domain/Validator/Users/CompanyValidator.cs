using FluentValidation;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Domain.Validator.Users;

public class CompanyValidator : AbstractValidator<Company>
{
    public CompanyValidator()
    {
    }
}
