using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution;

public class CreateMessageDiscutionRequest
{
    public CreateMessageDiscutionRequest(MessageDiscution messageDiscution, List<AttachedFile> attachedFiles)
    {
        this.MessageDiscution = messageDiscution;
        this.AttachedFiles = attachedFiles;
    }

    public MessageDiscution MessageDiscution {get; private set;}
    public List<AttachedFile> AttachedFiles {get; private set;}
    public Domain.Models.Shipping.Shipping? Shipping {get; set;}
    public List<AttachedFile> AttachedFilesBeforeSaveBlob {get; set;} = new();
    public MessageDiscution? MessageDiscutionOutput {get; set;}
    public List<AttachedFile> AttachedFilesOutput {get; set;} = new();
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.CreateMessageDiscution,message,DateTime.Now));
}
