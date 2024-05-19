using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.GetMyInformation;

public class GetMyInformationRequest
{
    public GetMyInformationRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id {get;private set;}

    public Company? Company {get; set;}

    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.GetMyInformation,message,DateTime.Now));
}
