using Newtonsoft.Json;

namespace Solidarize.Api.UseCases.Users.GetMyInformation;

public class GetMyInformationResponse
{
    public GetMyInformationResponse(Application.Bundaries.GetMyInformation.GetMyInformationResponse bundaries)
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
        };
    }
    public string? CompanyName { get; private set; }
    public List<string>? Images { get; private set; }
    public string? Icon { get; private set; }
    public string? Description { get; private set; }
    public string? LegalNature { get; private set; }
    public string? LocationX { get; private set; }
    public string? LocationY { get; private set; }
    public DateTime? LastAccessDate { get; private set; }
    public string? CNPJ { get; private set; }
    public string? Address { get; private set; }
    public string? Email { get; private set; }
    public string? Id { get; private set; }
}
