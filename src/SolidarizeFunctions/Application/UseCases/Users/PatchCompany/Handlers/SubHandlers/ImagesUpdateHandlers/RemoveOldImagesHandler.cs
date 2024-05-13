using Newtonsoft.Json;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.ImagesUpdateHandlers;

public class RemoveOldImagesHandler : Handler<PatchCompanyRequest>
{
    private readonly IImagesServices imagesServices;
    private readonly INotificationService notificationService;

    public RemoveOldImagesHandler
    (IImagesServices imagesServices, 
    INotificationService notificationService)
    {
        this.imagesServices = imagesServices;
        this.notificationService = notificationService;
    }
    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        if(request.Company!.Images!=null)
        {
            try
            {
            var imagesOldList = JsonConvert.DeserializeObject<List<string>>(request.Company.Images);

            imagesOldList!.ForEach(e=>{
                imagesServices.DeleteImage(e,Environment.GetEnvironmentVariable("UserContainerBlobs")!);
            });
            }
            catch{}
        }

        request.Company.Images= JsonConvert.SerializeObject(request.NewIdsImages);
        sucessor?.ProcessRequest(request);
    }
}
