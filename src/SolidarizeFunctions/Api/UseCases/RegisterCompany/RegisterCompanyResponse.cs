namespace Solidarize.Api.UseCases.RegisterCompany;

public class RegisterCompanyResponse
{
    public RegisterCompanyResponse(Application.Bundaries.RegisterCompany.RegisterCompanyResponse bundaries)
    {
        Id = bundaries.Id;
    }

    public Guid Id {get; private set;}

}
