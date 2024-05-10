using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.Users.Login;

public class LoginRequest
{
    [Required(AllowEmptyStrings=false)]
    public string Email {get; set;} = "";
    [Required(AllowEmptyStrings=false)]
    public string Password {get; set;} = "";
}
