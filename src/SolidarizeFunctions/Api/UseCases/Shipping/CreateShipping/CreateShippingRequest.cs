using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Shipping.CreateShipping;

public class CreateShippingRequest
{
    [Required]
    [JsonProperty("IdUserDestination")]
    public Guid IdUserDestination {get; set;}
    [Required]
    [JsonProperty("Description")]
    public string? Description {get; set;}
    [Required]
    [JsonProperty("Name")]
    public string? Name {get; set;}
}
