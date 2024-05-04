using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.RecoverPassword;

public class RecoverPasswordRequest
{
    public RecoverPasswordRequest(string email)
    {
        Email = email;
    }

    public string Email {get; private set;}
    public Company? Company {get; set;}
    public RequestRecoverPassword? RequestRecoverPassword {get; set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.RecoverPassword,message,DateTime.Now));
}
