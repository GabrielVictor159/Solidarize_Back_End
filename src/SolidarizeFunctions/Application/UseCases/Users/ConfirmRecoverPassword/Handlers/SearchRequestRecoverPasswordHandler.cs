using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;

public class SearchRequestRecoverPasswordHandler : Handler<ConfirmRecoverPasswordRequest>
{
    private readonly IRequestRecoverPasswordRepository requestRecoverPasswordRepository;
    private readonly INotificationService notificationService;

    public SearchRequestRecoverPasswordHandler
    (IRequestRecoverPasswordRepository requestRecoverPasswordRepository, 
    INotificationService notificationService)
    {
        this.requestRecoverPasswordRepository = requestRecoverPasswordRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(ConfirmRecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.RequestRecoverPassword = requestRecoverPasswordRepository.GetOne(request.IdRequest);

        if(request.RequestRecoverPassword is null)
        {
            notificationService.AddNotification("Id Request Not valid", "Não foi possivel encontrar a requisição de recuperação de senha com esse Id");
            return;
        }

        request.Email = request.RequestRecoverPassword.Body;

        sucessor?.ProcessRequest(request);
    }
}
