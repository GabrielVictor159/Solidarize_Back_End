using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Shipping.GetMyShippings;

public class GetMyShippingsRequest
{
    [JsonProperty("Name")]
    public string? Name {get;set;}
    [JsonProperty("IdShipping")]
    public Guid? IdShipping {get; set;}
}
