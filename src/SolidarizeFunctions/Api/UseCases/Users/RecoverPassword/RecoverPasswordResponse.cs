namespace Solidarize.Api.UseCases.Users.RecoverPassword;

public class RecoverPasswordResponse
{
    public RecoverPasswordResponse(Application.Bundaries.RecoverPassword.RecoverPasswordResponse bundaries)
    {
        if(bundaries.Id== Guid.Empty)
        {
            Sucess = false;
        }
    }

    public bool Sucess {get; private set;} = true;
}
