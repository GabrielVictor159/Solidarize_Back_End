using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.Login;

public class LoginRequest
{
    public LoginRequest(string email, string password)
    {
        Email = email;
        Password = password;
    }


    public string Email {get; private set;}
    public string Password {get; private set;}
    public string? Token {get; set;}
    public Company? Company {get; set;}
    public Password? PasswordUser {get; set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.Login,message,DateTime.Now));
}
