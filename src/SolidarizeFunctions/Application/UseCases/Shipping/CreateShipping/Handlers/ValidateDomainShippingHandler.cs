using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Shipping.CreateShipping.Handlers;

public class ValidateDomainShippingHandler : Handler<CreateShippingRequest>
{
    private readonly INotificationService notificationService;

    public ValidateDomainShippingHandler(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(CreateShippingRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        request.ShippingComunications = new Domain.Models.Shipping.Shipping(DateTime.Now,request.IdUserCreation,request.IdUserDestination, request.Description,request.Name,Guid.NewGuid());

        if(!request.ShippingComunications.IsValid)
        {
            notificationService.AddNotifications(request.ShippingComunications.ValidationResult);
            return;
        }
        
        sucessor?.ProcessRequest(request);
    }
}
