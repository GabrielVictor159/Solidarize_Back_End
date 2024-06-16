using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.Bundaries.CreateMessageDiscution;

public class CreateMessageDiscutionResponse
{
    public CreateMessageDiscutionResponse(MessageDiscution? messageDiscution, List<AttachedFile> attachedFiles)
    {
        MessageDiscution = messageDiscution;
        AttachedFiles = attachedFiles;
    }

    public MessageDiscution? MessageDiscution {get; private set;}
    public List<AttachedFile> AttachedFiles {get; private set;} = new();
}
