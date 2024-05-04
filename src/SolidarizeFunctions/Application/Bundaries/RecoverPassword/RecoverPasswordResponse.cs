namespace Solidarize.Application.Bundaries.RecoverPassword;

public class RecoverPasswordResponse
{
    public RecoverPasswordResponse(Guid id)
    {
        Id = id;
    }

    public Guid Id {get; set;}
}
