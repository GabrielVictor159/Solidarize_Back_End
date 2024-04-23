using System.ComponentModel.DataAnnotations;

namespace Solidarize.Api.UseCases.RegisterCompany;

public class RegisterCompanyRequest
{
    [Required]
    public string CompanyName {get; set;}
    public List<string> Images {get; set;}
    public string Icon {get; set;}
    [Required]
    public string Description {get; set;}
    [Required]
    public string LegalNature {get;set;}
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
