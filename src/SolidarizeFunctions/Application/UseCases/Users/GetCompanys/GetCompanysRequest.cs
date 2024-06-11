using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.GetCompanys;

public class GetCompanysRequest
{
    public GetCompanysRequest(Guid? idCompany, string? companyName, LegalNature? legalNature, string? cnpj, string? telefone, string? email)
    {
        IdCompany = idCompany;
        CompanyName = companyName;
        LegalNature = legalNature;
        Cnpj = cnpj;
        Telefone = telefone;
        Email = email;
    }

    public Guid? IdCompany {get; private set;}
    public string? CompanyName {get; private set;}
    public LegalNature? LegalNature { get; private set; }
    public string? Cnpj { get; private set; }
    public string? Telefone { get; private set; }
    public string? Email { get; private set; }
    public List<Company> Companies{get; set;} =new();
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.GetMyInformation,message,DateTime.Now));
}
