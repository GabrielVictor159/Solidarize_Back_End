using Newtonsoft.Json;
using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.MessageDiscution.GetMessagesDiscution;

public class GetMessagesDiscutionResponse
{
    public GetMessagesDiscutionResponse(Application.Bundaries.GetMessagesDiscution.GetMessagesDiscutionResponse boundaries)
    {
        boundaries.MessageDiscutions.ForEach(e =>
        {
            var a = new MessageDiscutionOutput(e.Id, e.Message, e.IdShipping, e.IdUser ?? Guid.NewGuid(), e.CreationDate);
            a.AttachedFiles.AddRange(e.AttachedFiles != null ? e.AttachedFiles.Select(z => new FilesResponse(z.Item, z.Type, z.CreationDate, z.IdMessageDiscution)): new List<FilesResponse>());
            MessageDiscutions.Add(a);
        });
        this.MessageDiscutions = this.MessageDiscutions.OrderByDescending(e=>e.CreationDate).ToList();
    }
    public List<MessageDiscutionOutput> MessageDiscutions { get; private set; } = new();
}
public class MessageDiscutionOutput
{
    public MessageDiscutionOutput(Guid id, string message, Guid idShipping, Guid idUser, DateTime creationDate)
    {
        Id = id;
        Message = message;
        IdShipping = idShipping;
        IdUser = idUser;
        CreationDate = creationDate;
    }

    [JsonProperty("Id")]
    public Guid Id { get; set; }
    [JsonProperty("Message")]
    public string Message { get; set; } = "";
    [JsonProperty("IdShipping")]
    public Guid IdShipping { get; set; }
    [JsonProperty("IdUser")]
    public Guid IdUser { get; set; }
    [JsonProperty("CreationDate")]
    public DateTime CreationDate { get; set; }
    [JsonProperty("AttachedFiles")]
    public List<FilesResponse> AttachedFiles { get; set; } = new();
}

public class FilesResponse
{
    public FilesResponse(string item, MessageFileType type, DateTime creationDate, Guid idMessageDiscution)
    {
        Item = item;
        Type = type;
        CreationDate = creationDate;
        IdMessageDiscution = idMessageDiscution;
    }

    [JsonProperty("Item")]
    public string Item { get; set; }

    [JsonProperty("Type")]
    public MessageFileType Type { get; set; }
    [JsonProperty("CreationDate")]
    public DateTime CreationDate { get; set; }
    [JsonProperty("IdMessageDiscution")]
    public Guid IdMessageDiscution { get; set; }
}