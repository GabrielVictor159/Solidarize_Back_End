using Solidarize.Domain.Enums;
using Solidarize.Domain.Models.Shipping;
using Solidarize.Domain.Validator.Users;

namespace Solidarize.Domain.Models.Users;

public class Company : Entity<Company, CompanyValidator>
{
    public Company(string companyName, string images, string icon, string description, LegalNature legalNature, string locationX, string locationY, bool banned, DateTime? banDate, DateTime? creationDate, DateTime? lastAccessDate, 
    string cnpj, string address, string telefone, string email, Guid id, Guid idpassword, Password? password)
    : base(new CompanyValidator())
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
    public string Images { get; set; }
    public string Icon { get; set; }
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

    public Password? Password { get; set; }
    public virtual ICollection<MessageDiscution>? MessageDiscutions { get; set; }
    public virtual ICollection<Shipping.Shipping>? ShippingIdUserCreationNavigations { get; set; }
    public virtual ICollection<Shipping.Shipping>? ShippingIdUserResponseNavigations { get; set; }
}
