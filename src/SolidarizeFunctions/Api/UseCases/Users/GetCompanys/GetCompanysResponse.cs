using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Users.GetCompanys;

public class GetCompanysResponse
{
    public GetCompanysResponse(Application.Bundaries.GetCompanys.GetCompanysResponse bundaries)
    {
        this.Companies.AddRange(
            bundaries.Companies.Select(e => 
            new GetCompanysOutput(
                e.CompanyName,
                e.Images != null?JsonConvert.DeserializeObject<List<string>>(e.Images) : new(),
                e.Icon,e.Description,
                e.LegalNature.ToString(),
                e.LocationX,
                e.LocationY,
                e.LastAccessDate,
                e.Cnpj,e.Address,
                e.Email,
                e.Telefone,
                e.Id.ToString()))
        );
    }
    [JsonProperty("Companies")]
    public List<GetCompanysOutput> Companies {get; set;} = new();
}
 public class GetCompanysOutput
 {
    public GetCompanysOutput(string? companyName, List<string>? images, string? icon, string? description, string? legalNature, string? locationX, string? locationY, DateTime? lastAccessDate, 
    string? cNPJ, string? address, string? email, string? telefone, string? id)
    {
        CompanyName = companyName;
        Images = images;
        Icon = icon;
        Description = description;
        LegalNature = legalNature;
        LocationX = locationX;
        LocationY = locationY;
        LastAccessDate = lastAccessDate;
        CNPJ = cNPJ;
        Address = address;
        Email = email;
        Telefone = telefone;
        Id = id;
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
