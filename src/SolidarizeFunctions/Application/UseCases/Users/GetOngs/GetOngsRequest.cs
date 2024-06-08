using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.GetOngs;

public class GetOngsRequest
{
    public List<Company> Companies {get; set;} = new();
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.RequestRegisterCompany,message,DateTime.Now));
}
