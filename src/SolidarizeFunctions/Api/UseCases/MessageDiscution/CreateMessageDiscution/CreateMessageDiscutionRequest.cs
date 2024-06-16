using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.MessageDiscution.CreateMessageDiscution;

public class CreateMessageDiscutionRequest
{
    [Required]
    [JsonProperty("Message")]
    public string Message {get; set;} ="";

    [Required]
    [JsonProperty("IdShipping")]
    public Guid IdShipping {get;set;}

    [JsonProperty("Files")]
    public List<FilesRequest> Files {get; set;} = new();
}

public class FilesRequest
{
    [Required]
    [JsonProperty("Item")]
     public string Item {get; set;}
    [Required]
    [JsonProperty("Type")]
    public MessageFileType Type {get;set;}
}
