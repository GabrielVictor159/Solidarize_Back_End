using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.Users.PatchCompany;

public class PatchCompanyRequest
{
    public List<string>? Images { get; set; }
    public string? Icon { get; set; }
    public string? CompanyName {get; set;}
    public string? Description {get; set;}
    public LegalNature? LegalNature {get;set;}
    public DateTime? LastAccessDate { get; set; }
    public string? LocationX {get;set;}
    public string? LocationY {get;set;}
    public string? CNPJ {get;set;}
    public string? Address {get;set;}
    public string? Telefone {get;set;}
    public string? Password {get;set;}
}
