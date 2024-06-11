using Solidarize.Domain.Models.Users;
using Solidarize.Domain.Validator.Shipping;

namespace Solidarize.Domain.Models.Shipping;

public class Shipping : Entity<Shipping,ShippingValidator>
{
    public Shipping(DateTime creationDate, Guid idUserCreation, Guid idUserResponse, string? description, string? name, Guid id)
    : base(new ShippingValidator())
    {
        CreationDate = creationDate;
        IdUserCreation = idUserCreation;
        IdUserResponse = idUserResponse;
        Description = description;
        Name = name;
        Id = id;
    }

    public DateTime CreationDate { get; private set; }
    public Guid IdUserCreation { get; private set; }
    public Guid IdUserResponse { get; private set; }
    public string? Description { get; private set; }
    public string? Name { get; private set; }
    public Guid Id { get; private set; }

    public Company? IdUserCreationNavigation { get; set; }
    public Company? IdUserResponseNavigation { get; set; }
    public ICollection<MessageDiscution>? MessageDiscution { get; set; }
}
