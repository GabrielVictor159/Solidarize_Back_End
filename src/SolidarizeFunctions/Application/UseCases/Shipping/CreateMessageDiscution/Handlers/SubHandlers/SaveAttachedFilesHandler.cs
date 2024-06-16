using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers.SubHandlers;

public class SaveAttachedFilesHandler : Handler<CreateMessageDiscutionRequest>
{
    private readonly IFileService fileService;

    public SaveAttachedFilesHandler(IFileService fileService)
    {
        this.fileService = fileService;
    }

    public override void ProcessRequest(CreateMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.AttachedFiles.ForEach(e=>
        {
           var result = fileService.SaveFile(e.Item,"messages", e.Type);
           if(result.Sucess)
           {
                request.AttachedFilesBeforeSaveBlob.Add(new(e.Id,result.Id,e.Type,e.CreationDate,e.IdMessageDiscution));
           }
           else
           {
                request.AddLog(Domain.Enums.LogType.INFO, result.e!.Message);
           }
        });

        sucessor?.ProcessRequest(request);
    }
}
