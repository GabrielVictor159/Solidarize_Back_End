using Newtonsoft.Json;
using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers;

public class SaveMessageDiscutionHandler : Handler<CreateMessageDiscutionRequest>
{
    private readonly IMessageDiscutionRepository messageDiscutionRepository;
    private readonly IAttachedFileRepository attachedFileRepository;
    private readonly INotificationService notificationService;

    public SaveMessageDiscutionHandler(IMessageDiscutionRepository messageDiscutionRepository, IAttachedFileRepository attachedFileRepository, INotificationService notificationService)
    {
        this.messageDiscutionRepository = messageDiscutionRepository;
        this.attachedFileRepository = attachedFileRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(CreateMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        var resultMessageDiscution =messageDiscutionRepository.Add(request.MessageDiscution);
        if(resultMessageDiscution<1)
        {
            notificationService.AddNotification("Error Save Message Discution", "Não foi possivel salvar sua mensagem na base de dados.");
            request.AddLog(Domain.Enums.LogType.PROCESS,$"Não foi possivel salvar a messageDiscution = {JsonConvert.SerializeObject(request.MessageDiscution)}");
            return;
        }
        request.MessageDiscutionOutput = request.MessageDiscution;
        request.AttachedFilesBeforeSaveBlob.ForEach(e=>
        {
            var result =attachedFileRepository.Add(e);
            if(result>0)
            {
                request.AttachedFilesOutput.Add(e);
            }
        });


        sucessor?.ProcessRequest(request);
    }
}
