using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyRequest
{
    public required string CompanyName {get; set;}
    public required string Description {get; set;}
    public required string LegalNature {get;set;}
    public required string LocationX {get;set;}
    public required string LocationY {get;set;}
    public required string CNPJ {get;set;}
    public required string Address {get;set;}
    public string Telefone {get;set;}
    public required string Email {get;set;}
    public required string Password {get;set;}
    public Password PasswordObject {get; set;}
    
}
