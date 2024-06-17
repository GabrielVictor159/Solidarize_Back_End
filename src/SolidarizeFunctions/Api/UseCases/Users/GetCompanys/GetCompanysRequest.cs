using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.Users.GetCompanys;

public class GetCompanysRequest
{
    public List<Guid>? IdsCompanys {get;set;}
    public Guid? IdCompany {get; set;}
    public string? CompanyName {get; set;}
    public LegalNature? LegalNature { get; set; }
    public string? Cnpj { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}
