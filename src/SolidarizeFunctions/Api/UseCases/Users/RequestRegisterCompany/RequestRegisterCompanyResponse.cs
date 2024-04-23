namespace Solidarize.Api.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyResponse
{
    public RequestRegisterCompanyResponse(Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse bundaries)
    {
        Id = bundaries.Id;
    }

    public Guid Id {get; private set;}

}
