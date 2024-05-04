namespace Solidarize.Application.Bundaries.ConfirmRegisterCompany;

public class ConfirmRegisterCompanyResponse
{
    public ConfirmRegisterCompanyResponse(Guid idUser, Guid idPassword)
    {
        IdUser = idUser;
        IdPassword = idPassword;
    }

    public Guid IdUser {get; set;}
    public Guid IdPassword {get; set;}
}
