using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyRequest
{
    public string CompanyName {get; private set;}
    public string Description {get; private set;}
    public LegalNature LegalNature {get;private set;}
    public string LocationX {get;private set;}
    public string LocationY {get;private set;}
    public string CNPJ {get;private set;}
    public string Address {get;private set;}
    public string Telefone {get;private set;}
    public string Email {get;private set;}
    public string Password {get;private set;}
    public Password? PasswordObject {get; set;}
    public RequestCompany? RequestCompany {get;set;}
    public Company? Company {get;set;}
    public List<Log> Logs { get; set; } = new();
    public void AddLog(LogType type, string message)
           => Logs.Add(new Log(Guid.NewGuid(),type,Domain.Enums.UseCases.RequestRegisterCompany,message,DateTime.Now));
    public RequestRegisterCompanyRequest(string companyName, string description, LegalNature legalNature, string locationX, string locationY, string cNPJ, string address, string email, string password, string telefone = "")
    {
        CompanyName = companyName;
        Description = description;
        LegalNature = legalNature;
        LocationX = locationX;
        LocationY = locationY;  
        CNPJ = cNPJ;
        Address = address;
        Telefone = telefone;
        Email = email;
        Password = password;
    }
    
}
