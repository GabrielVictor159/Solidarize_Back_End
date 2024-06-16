using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;

namespace Solidarize.Application.UseCases.Shipping.GetMessagesDiscution;

public class GetMessageDiscutionRequest
{
    public GetMessageDiscutionRequest(Guid idUser, Guid idShipping)
    {
        IdUser = idUser;
        IdShipping = idShipping;
    }

    public Guid IdUser {get; private set;}
    public Guid IdShipping {get; private set;}
    public Domain.Models.Shipping.Shipping? Shipping {get;set;}
    public List<Domain.Models.Shipping.MessageDiscution> MessageDiscutions {get; set;} = new();
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.GetMessagesDiscution,message,DateTime.Now));
}
