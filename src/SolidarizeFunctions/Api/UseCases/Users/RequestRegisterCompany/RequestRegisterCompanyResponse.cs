namespace Solidarize.Api.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyResponse
{
    public RequestRegisterCompanyResponse(Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse bundaries)
    {
        if(bundaries.Id== Guid.Empty)
        {
            Sucess = false;
        }
    }

    public bool Sucess {get; private set;} = true;

}
