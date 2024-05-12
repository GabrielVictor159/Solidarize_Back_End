namespace Solidarize.Api.UseCases.Users.Login;

public class LoginResponse
{
    public LoginResponse(Application.Bundaries.Login.LoginResponse loginResponse)
    {
        if(loginResponse!=null && loginResponse.Token!=null)
        {
        Token=loginResponse.Token;
        }
    }
    public string Token {get; set;}= "";
}
