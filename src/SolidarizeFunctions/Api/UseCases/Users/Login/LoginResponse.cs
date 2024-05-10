namespace Solidarize.Api.UseCases.Users.Login;

public class LoginResponse
{
    public LoginResponse(Application.Bundaries.Login.LoginResponse loginResponse)
    {
        Token=loginResponse.Token;
    }
    public string? Token {get; set;}
}
