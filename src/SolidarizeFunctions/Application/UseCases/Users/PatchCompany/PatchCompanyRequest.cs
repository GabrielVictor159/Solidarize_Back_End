using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.PatchCompany;

public class PatchCompanyRequest
{

    public PatchCompanyRequest(Guid idUser)
    {
        IdUser = idUser;
    }

    public PatchCompanyRequest(Guid idUser, List<string>? images, string? icon, string? companyName, string? description, LegalNature? legalNature, DateTime? lastAccessDate, string? locationX, string? locationY, string? cNPJ, string? address, string? telefone, string? password)
    {
        IdUser = idUser;
        Images = images;
        Icon = icon;
        CompanyName = companyName;
        Description = description;
        LegalNature = legalNature;
        LastAccessDate = lastAccessDate;
        LocationX = locationX;
        LocationY = locationY;
        CNPJ = cNPJ;
        Address = address;
        Telefone = telefone;
        Password = password;
    }

    public Guid IdUser {get; private set;}
    public List<string>? Images { get; private set; }
    public string? Icon { get; private set; }
    public string? IdNewIcon {get; set;}
    public List<string> NewIdsImages {get;set;}= new();
    public string? CompanyName {get; private set;}
    public string? Description {get; private set;}
    public LegalNature? LegalNature {get;private set;}
    public DateTime? LastAccessDate { get;private set; }
    public string? LocationX {get;private set;}
    public string? LocationY {get;private set;}
    public string? CNPJ {get;private set;}
    public string? Address {get;private set;}
    public string? Telefone {get;private set;}
    public string? Password {get;private set;}
    public Company? Company {get; set;}
    public Password? PasswordObject {get; set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.PatchCompany,message,DateTime.Now));
}
