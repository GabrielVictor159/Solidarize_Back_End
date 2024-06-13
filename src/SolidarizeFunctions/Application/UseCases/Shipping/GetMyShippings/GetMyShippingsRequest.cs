using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;

namespace Solidarize.Application.UseCases.Shipping.GetMyShippings;

public class GetMyShippingsRequest
{
    public GetMyShippingsRequest(Guid idUser, string? name, Guid? id)
    {
        IdUser = idUser;
        Name = name;
        Id = id;
    }

    public Guid IdUser {get; private set;}
    public string? Name {get; private set;}
    public Guid? Id {get; private set;}
    public List<Domain.Models.Shipping.Shipping> Shippings {get; set;} = new();
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.GetMyShippings,message,DateTime.Now));
}
