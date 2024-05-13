using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.IconUpdateHandlers;

public class RemoveOldIconHandler : Handler<PatchCompanyRequest>
{
    private readonly IImagesServices imagesServices;
    private readonly INotificationService notificationService;

    public RemoveOldIconHandler
    (IImagesServices imagesServices, 
    INotificationService notificationService)
    {
        this.imagesServices = imagesServices;
        this.notificationService = notificationService;
    }
    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        if(request.Company!.Icon!=null)
        {
            imagesServices.DeleteImage(request.Company.Icon,Environment.GetEnvironmentVariable("UserContainerBlobs")!);
        }

        request.Company.Icon = request.IdNewIcon!;
        sucessor?.ProcessRequest(request);
    }
}
