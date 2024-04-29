using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.Users.ConfirmRegisterCompany;

public class ConfirmRegisterCompanyRequest
{
    [Required]
    public Guid Id {get; set;}
}
