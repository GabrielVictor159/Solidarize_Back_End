using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Shipping.GetMyShippings;

public class GetMyShippingsResponse
{
    public GetMyShippingsResponse(Application.Bundaries.GetMyShippings.GetMyShippingsResponse getMyShippingsResponse)
    {
        this.Shippings.AddRange(
            getMyShippingsResponse.Shippings.Select(e => 
            new GetShippingsOutput(e.CreationDate,e.IdUserCreation,e.IdUserResponse,e.Description,e.Name,e.Id)));
    }
    public List<GetShippingsOutput> Shippings {get; private set;} = new();
}
public class GetShippingsOutput
{
    public GetShippingsOutput(DateTime creationDate, Guid idUserCreation, Guid idUserResponse, string? description, string? name, Guid id)
    {
        CreationDate = creationDate;
        IdUserCreation = idUserCreation;
        IdUserResponse = idUserResponse;
        Description = description;
        Name = name;
        Id = id;
    }

    [JsonProperty("CreationDate")]
    public DateTime CreationDate { get; private set; }
    [JsonProperty("IdUserCreation")]
    public Guid IdUserCreation { get; private set; }
    [JsonProperty("IdUserResponse")]
    public Guid IdUserResponse { get; private set; }
    [JsonProperty("Description")]
    public string? Description { get; private set; }
    [JsonProperty("Name")]
    public string? Name { get; private set; }
    [JsonProperty("Id")]
    public Guid Id { get; private set; }
}