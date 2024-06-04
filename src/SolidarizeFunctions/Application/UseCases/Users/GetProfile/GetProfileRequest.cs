using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.GetProfile;

public class GetProfileRequest
{
    public GetProfileRequest(Guid id)
    {
        Id = id;
    }

    public Guid Id {get; private set;}
    public Company? company {get;set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.GetProfile,message,DateTime.Now));
}
