using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.MessageDiscution.CreateMessageDiscution;

public class CreateMessageDiscutionRequest
{
    [Required]
    [JsonProperty("Message")]
    public string Message {get; set;} ="";

    [Required]
    [JsonProperty("IdShipping")]
    public Guid IdShipping {get;set;}
}
