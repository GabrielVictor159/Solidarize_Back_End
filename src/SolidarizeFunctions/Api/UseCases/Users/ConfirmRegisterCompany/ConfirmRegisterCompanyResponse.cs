namespace Solidarize.Api.UseCases.Users.ConfirmRegisterCompany;

public class ConfirmRegisterCompanyResponse
{
    public ConfirmRegisterCompanyResponse(Application.Bundaries.ConfirmRegisterCompany.ConfirmRegisterCompanyResponse bundaries)
    {
        if(bundaries.IdUser== Guid.Empty || bundaries.IdPassword == Guid.Empty)
        {
            Sucess = false;
        }
    }

    public bool Sucess {get; private set;} = true;
}
