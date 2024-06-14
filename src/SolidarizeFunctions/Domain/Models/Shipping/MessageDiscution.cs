using Solidarize.Domain.Models.Users;
using Solidarize.Domain.Validator.Shipping;

namespace Solidarize.Domain.Models.Shipping;

public class MessageDiscution : Entity<MessageDiscution,MessageDiscutionValidator>
{
    public MessageDiscution(Guid id, Guid idShipping, string message, Guid idUser, DateTime creationDate)
    : base(new MessageDiscutionValidator())
    {
        Id = id;
        IdShipping = idShipping;
        Message = message;
        IdUser = idUser;
        CreationDate = creationDate;
    }

    public Guid Id { get; private set; }
    public Guid IdShipping { get; private set; }
    public string Message { get; private set; }
    public Guid? IdUser { get; private set; }
    public DateTime CreationDate {get; private set;}

    public virtual Shipping? IdShippingNavigation { get; set; }
    public virtual Company? IdUserNavigation { get; set; }
    public virtual ICollection<AttachedFile>? AttachedFiles { get; set; }
}
