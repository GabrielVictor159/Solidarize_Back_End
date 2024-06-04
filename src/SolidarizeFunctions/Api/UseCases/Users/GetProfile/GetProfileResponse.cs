using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Users.GetProfile;

public class GetProfileResponse
{
    public GetProfileResponse(Application.Bundaries.GetProfile.GetProfileResponse bundaries)
    {
        if(bundaries.company!=null)
        {
             this.CompanyName = bundaries.company.CompanyName;
            this.Images = bundaries.company.Images != null?JsonConvert.DeserializeObject<List<string>>(bundaries.company.Images) : new();
            this.Icon = bundaries.company.Icon;
            this.Description = bundaries.company.Description;
            this.LegalNature = bundaries.company.LegalNature.ToString();
            this.LocationX = bundaries.company.LocationX;
            this.LocationY = bundaries.company.LocationY;
            this.LastAccessDate = bundaries.company.LastAccessDate;
            this.CNPJ = bundaries.company.Cnpj;
            this.Address = bundaries.company.Address;
            this.Email = bundaries.company.Email;
            this.Id = bundaries.company.Id.ToString();
            this.Telefone = bundaries.company.Telefone;
        }
    }

    [JsonProperty("CompanyName")]
    public string? CompanyName { get; private set; }
    [JsonProperty("Images")]
    public List<string>? Images { get; private set; }
    [JsonProperty("Icon")]
    public string? Icon { get; private set; }
    [JsonProperty("Description")]
    public string? Description { get; private set; }
    [JsonProperty("LegalNature")]
    public string? LegalNature { get; private set; }
    [JsonProperty("LocationX")]
    public string? LocationX { get; private set; }
    [JsonProperty("LocationY")]
    public string? LocationY { get; private set; }
    [JsonProperty("LastAccessDate")]
    public DateTime? LastAccessDate { get; private set; }
    [JsonProperty("CNPJ")]
    public string? CNPJ { get; private set; }
    [JsonProperty("Address")]
    public string? Address { get; private set; }
    [JsonProperty("Email")]
    public string? Email { get; private set; }
    [JsonProperty("Telefone")]
    public string? Telefone { get; private set; }
    [JsonProperty("Id")]
    public string? Id { get; private set; }
}
