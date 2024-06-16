using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.MessageDiscution.CreateMessageDiscution;

public class CreateMessageDiscutionResponse
{
    public CreateMessageDiscutionResponse(Application.Bundaries.CreateMessageDiscution.CreateMessageDiscutionResponse createMessageDiscution)
    {
        if(createMessageDiscution.MessageDiscution!=null)
        {
            this.Id = createMessageDiscution.MessageDiscution.Id;
            this.Message = createMessageDiscution.MessageDiscution.Message;
            this.IdShipping = createMessageDiscution.MessageDiscution.IdShipping;
            this.IdUser = createMessageDiscution.MessageDiscution.IdUser ?? Guid.Empty;
            this.CreationDate = createMessageDiscution.MessageDiscution.CreationDate;
        }
         this.AttachedFiles.AddRange(
            createMessageDiscution.AttachedFiles.Select(e => 
            new FilesResponse(e.Item,e.Type,e.CreationDate,e.IdMessageDiscution)));
    }

    [JsonProperty("Id")]
    public Guid Id {get;set;}
    [JsonProperty("Message")]
    public string Message {get; set;} ="";
    [JsonProperty("IdShipping")]
    public Guid IdShipping {get;set;}
    [JsonProperty("IdUser")]
    public Guid IdUser {get;set;}
    [JsonProperty("CreationDate")]
    public DateTime CreationDate {get;set;}
    [JsonProperty("AttachedFiles")]
    public List<FilesResponse> AttachedFiles {get;set;} = new();
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
     public string Item {get; set;}

    [JsonProperty("Type")]
    public MessageFileType Type {get;set;}
    [JsonProperty("CreationDate")]
    public DateTime CreationDate {get;set;}
    [JsonProperty("IdMessageDiscution")]
    public Guid IdMessageDiscution {get;set;}
}