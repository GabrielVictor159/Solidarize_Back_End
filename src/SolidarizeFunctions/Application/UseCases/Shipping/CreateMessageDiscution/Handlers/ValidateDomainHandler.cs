using Azure.Core;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers.SubHandlers;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers;

public class ValidateDomainHandler : Handler<CreateMessageDiscutionRequest>
{
    private readonly INotificationService notificationService;
    private readonly SaveAttachedFilesHandler saveAttachedFilesHandler;

    public ValidateDomainHandler(INotificationService notificationService, SaveAttachedFilesHandler saveAttachedFilesHandler)
    {
        this.notificationService = notificationService;
        this.saveAttachedFilesHandler = saveAttachedFilesHandler;
    }

    public override void ProcessRequest(CreateMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        if(!request.MessageDiscution.IsValid)
        {
            notificationService.AddNotifications(request.MessageDiscution.ValidationResult);
            return;
        }

        request.AttachedFiles.ForEach(e=>
        {
            if(!e.IsValid)
            {
                notificationService.AddNotifications(e.ValidationResult);
                return;
            }
        });
        saveAttachedFilesHandler.ProcessRequest(request);
        sucessor?.ProcessRequest(request);
    }
}
