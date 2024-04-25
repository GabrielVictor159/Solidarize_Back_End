namespace Solidarize.Application.Bundaries.RequestRegisterCompany;

public class RequestRegisterCompanyResponse
{
    public RequestRegisterCompanyResponse(Guid id)
    {
        Id = id;
    }

    public Guid Id {get; private set;}
}
