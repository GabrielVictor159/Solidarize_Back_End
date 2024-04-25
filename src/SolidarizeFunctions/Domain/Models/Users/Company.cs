using Solidarize.Domain.Enums;

namespace Solidarize.Domain.Models.Users;

public class Company
{
    public Company(string companyName, string images, string icon, string description, LegalNature legalNature, string locationX, string locationY, bool banned, DateTime? banDate, DateTime? creationDate, DateTime? lastAccessDate, 
    string cnpj, string address, string telefone, string email, Guid id, Guid idpassword, Password password)
    {
        CompanyName = companyName;
        Images = images;
        Icon = icon;
        Description = description;
        LegalNature = legalNature;
        LocationX = locationX;
        LocationY = locationY;
        Banned = banned;
        BanDate = banDate;
        CreationDate = creationDate;
        LastAccessDate = lastAccessDate;
        Cnpj = cnpj;
        Address = address;
        Telefone = telefone;
        Email = email;
        Id = id;
        Idpassword = idpassword;
        Password = password;
    }

    public string CompanyName { get; private set; }
    public string Images { get; private set; }
    public string Icon { get; private set; }
    public string Description { get; private set; }
    public LegalNature LegalNature { get; private set; }
    public string LocationX { get; private set; }
    public string LocationY { get; private set; }
    public bool Banned { get; private set; }
    public DateTime? BanDate { get; private set; }
    public DateTime? CreationDate { get; private set; }
    public DateTime? LastAccessDate { get; private set; }
    public string Cnpj { get; private set; }
    public string Address { get; private set; }
    public string Telefone { get; private set; }
    public string Email { get; private set; }
    public Guid Id { get; private set; }
    public Guid Idpassword { get; private set; }

    public Password Password { get; private set; }
}
