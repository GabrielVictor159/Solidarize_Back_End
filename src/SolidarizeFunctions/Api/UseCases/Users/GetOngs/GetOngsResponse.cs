using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Users.GetOngs;

public class GetOngsResponse
{
    public record GetOngsOutput([JsonProperty("Id")] Guid Id,[JsonProperty("Icon")] string Icon, [JsonProperty("CompanyName")] string CompanyName,[JsonProperty("Address")] string Address,[JsonProperty("Description")] string Description, [JsonProperty("LocationX")] string LocationX,[JsonProperty("LocationY")] string LocationY);
    public GetOngsResponse(Application.Bundaries.GetOngs.GetOngsResponse bundaries)
    {
        this.Companies.AddRange(
            bundaries.Companies.Select(e => new GetOngsOutput(e.Id,e.Icon, e.CompanyName, e.Address, e.Description, e.LocationX, e.LocationY))
        );
    }

    [JsonProperty("Companies")]
    public List<GetOngsOutput> Companies {get; set;} = new();

}

