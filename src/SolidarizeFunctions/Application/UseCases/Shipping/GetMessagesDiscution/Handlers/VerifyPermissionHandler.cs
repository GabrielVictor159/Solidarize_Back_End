using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Shipping.GetMessagesDiscution.Handlers;

public class VerifyPermissionHandler : Handler<GetMessageDiscutionRequest>
{
    private readonly IShippingRepository shippingRepository;
    private readonly INotificationService notificationService;

    public VerifyPermissionHandler(IShippingRepository shippingRepository, INotificationService notificationService)
    {
        this.shippingRepository = shippingRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(GetMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        request.Shipping = shippingRepository.GetOne(request.IdShipping);
        if(request.Shipping is null)
        {
            notificationService.AddNotification("Shipping Not Found","Não foi possivel encontrar a doação associada a mensagem.");
            return;
        }
        if(request.Shipping.IdUserCreation != request.IdUser && request.Shipping.IdUserResponse != request.IdUser)
        {
            notificationService.AddNotification("Not Permission","Você não tem permissão para ver essas mensagens.");
            return;
        }
        sucessor?.ProcessRequest(request);
    }
}
