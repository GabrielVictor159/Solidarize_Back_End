using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.ConfirmRecoverPassword;

public class ConfirmRecoverPasswordResponse
{
    public ConfirmRecoverPasswordResponse(string newPassword, Password password)
    {
        NewPassword = newPassword;
        this.password = password;
    }

    public string NewPassword {get; set;}
    public Password password {get; set;}
}
