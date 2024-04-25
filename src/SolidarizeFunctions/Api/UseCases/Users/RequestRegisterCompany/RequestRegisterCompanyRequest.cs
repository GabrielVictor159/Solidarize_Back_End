using System.ComponentModel.DataAnnotations;
using Solidarize.Domain.Enums;

namespace Solidarize.Api.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyRequest
{
    [Required]
    public string CompanyName {get; set;}
    [Required]
    public string Description {get; set;}
    [Required]
    public LegalNature LegalNature {get;set;}
    [Required]
    public string LocationX {get;set;}
    [Required]
    public string LocationY {get;set;}
    [Required]
    public string CNPJ {get;set;}
    [Required]
    public string Address {get;set;}
    public string Telefone {get;set;}
    [Required]
    public string Email {get;set;}
    [Required]
    public string Password {get;set;}

}
