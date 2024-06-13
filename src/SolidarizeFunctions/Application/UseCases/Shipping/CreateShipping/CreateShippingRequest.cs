using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;

namespace Solidarize.Application.UseCases.Shipping.CreateShipping;

public class CreateShippingRequest
{
    public CreateShippingRequest(Guid idUserCreation, Guid idUserDestination, string? description, string? name)
    {
        IdUserCreation = idUserCreation;
        IdUserDestination = idUserDestination;
        Description = description;
        Name = name;
    }

    public Guid IdUserCreation {get; private set;}
    public Guid IdUserDestination {get; private set;}
    public string? Description {get; private set;}
    public string? Name {get; private set;}
    public Domain.Models.Shipping.Shipping? Shipping {get;set;}
    public Domain.Models.Shipping.Shipping? ShippingComunications {get;set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.CreateShipping,message,DateTime.Now));
}
