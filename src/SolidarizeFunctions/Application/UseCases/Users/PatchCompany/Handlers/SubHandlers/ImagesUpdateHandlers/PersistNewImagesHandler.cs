using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.ImagesUpdateHandlers;

public class PersistNewImagesHandler : Handler<PatchCompanyRequest>
{
    private readonly IImagesServices imagesServices;
    private readonly INotificationService notificationService;

    public PersistNewImagesHandler
    (IImagesServices imagesServices, 
    INotificationService notificationService)
    {
        this.imagesServices = imagesServices;
        this.notificationService = notificationService;
    }
    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        if(request.Images!.Count>6)
        {
            notificationService.AddNotification("Lots of images","O numero maximo de imagens por empresa é 6");
            return;
        }

        request.Images.ForEach(e=>{
            var result = imagesServices.SaveImage(e,Environment.GetEnvironmentVariable("UserContainerBlobs")!);
            if(result.Sucess)
            request.NewIdsImages.Add(result.Id);
        });

        sucessor?.ProcessRequest(request);
    }
}
