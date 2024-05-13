using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.IconUpdateHandlers;

public class PersistNewIconHandler : Handler<PatchCompanyRequest>
{
    private readonly IImagesServices imagesServices;
    private readonly INotificationService notificationService;

    public PersistNewIconHandler
    (IImagesServices imagesServices, 
    INotificationService notificationService)
    {
        this.imagesServices = imagesServices;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        var resultPerist = imagesServices.SaveImage(request.Icon!,Environment.GetEnvironmentVariable("UserContainerBlobs")!);
        if(!resultPerist.Sucess)
        {
            notificationService.AddNotification("Error Save Image",resultPerist.e!.Message);
            return;
        }
        request.IdNewIcon = resultPerist.Id;
        sucessor?.ProcessRequest(request);
    }
}
