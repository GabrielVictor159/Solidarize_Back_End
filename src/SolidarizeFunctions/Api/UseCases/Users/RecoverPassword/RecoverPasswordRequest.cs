using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.Users.RecoverPassword;

public class RecoverPasswordRequest
{
    [Required]
    public string Email {get;set;}
}
