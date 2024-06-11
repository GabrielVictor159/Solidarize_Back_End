using Solidarize.Domain.Enums;
using Solidarize.Domain.Validator.Shipping;

namespace Solidarize.Domain.Models.Shipping;

public class AttachedFile : Entity<AttachedFile,AttachedFileValidator>
{
    public AttachedFile(Guid id, string item, MessageFileType type, DateTime creationDate, Guid idMessageDiscution)
    : base(new AttachedFileValidator())
    {
        Id = id;
        Item = item;
        Type = type;
        CreationDate = creationDate;
        IdMessageDiscution = idMessageDiscution;
    }

    public Guid Id { get; private set; }
    public string Item { get; private set; }
    public MessageFileType Type { get; private set; }
    public DateTime CreationDate { get; private set; }
    public Guid IdMessageDiscution { get; private set; }

    public virtual MessageDiscution? IdMessageDiscutionNavigation { get; set; }
}
