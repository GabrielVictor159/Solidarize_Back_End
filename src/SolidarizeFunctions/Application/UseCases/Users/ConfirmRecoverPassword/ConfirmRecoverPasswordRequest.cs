using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword;

public class ConfirmRecoverPasswordRequest
{
    public ConfirmRecoverPasswordRequest(Guid idRequest, string newPassword)
    {
        IdRequest = idRequest;
        NewPassword = newPassword;
    }

    public Guid IdRequest {get; private set;}
    public string NewPassword {get; private set;}

    public string? Email {get; set;}
    public Company? Company {get;set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.ConfirmRecoverPassword,message,DateTime.Now));
}
