using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.Users.ConfirmRecoverPassword;

public class ConfirmRecoverPasswordRequest
{
    [Required]
    public Guid IdRequest {get; set;}
    [Required]
    public string NewPassword {get;set;} = "";
}