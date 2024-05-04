using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany;

public class ConfirmRegisterCompanyRequest
{
    public ConfirmRegisterCompanyRequest(Guid idRequest)
    {
        IdRequest = idRequest;
    }

    public Guid IdRequest {get; private set;}
    public RequestCompany? RequestCompany {get; set;}
    public Password? Password {get; set;}
    public Company? Company {get; set;}

    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.RequestRegisterCompany,message,DateTime.Now));
}
