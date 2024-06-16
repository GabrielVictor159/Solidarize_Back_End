using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers;

public class VerifyCreationHandler : Handler<CreateMessageDiscutionRequest>
{
    private readonly IShippingRepository shippingRepository;
    private readonly INotificationService notificationService;

    public VerifyCreationHandler(IShippingRepository shippingRepository, INotificationService notificationService)
    {
        this.shippingRepository = shippingRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(CreateMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        var shipping = shippingRepository.GetOne(request.MessageDiscution.IdShipping);
        if(shipping==null)
        {
            notificationService.AddNotification("Shipping Not Found", "Não foi encontrado uma doação com esse Id.");
            return;
        }
        if(shipping.IdUserCreation != request.MessageDiscution.IdUser && shipping.IdUserResponse!= request.MessageDiscution.IdUser)
        {
            notificationService.AddNotification("Not Permited", "Você não tem permissão para criar essa mensagem.");
            return;
        }
        request.Shipping = shipping;
        sucessor?.ProcessRequest(request);
    }
}
