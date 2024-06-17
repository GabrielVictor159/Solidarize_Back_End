using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.MessageDiscution.GetMessagesDiscution;

public class GetMessagesDiscutionRequest
{
    [JsonProperty("IdShipping")]
    public Guid IdShipping {get; set;}
}
