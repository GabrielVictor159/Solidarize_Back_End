using Solidarize.Domain.Cryptography;

namespace Solidarize.Api.UseCases.Users.ConfirmRecoverPassword;

public class ConfirmRecoverPasswordResponse
{
    public ConfirmRecoverPasswordResponse(Application.Bundaries.ConfirmRecoverPassword.ConfirmRecoverPasswordResponse confirmRecoverPasswordResponse)
    {
        var result = confirmRecoverPasswordResponse.NewPassword.PasswordEncryption().Result;
        if(!confirmRecoverPasswordResponse.password.PasswordValue.Equals(result))
        {
            this.Sucess = false;
        }
    }

    public bool Sucess = true;
}
