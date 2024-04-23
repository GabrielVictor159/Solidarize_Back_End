namespace Solidarize.Domain.Models.Chat;

public class Chat
{
    public Chat(Guid id, DateTime creationDate, string users)
    {
        Id = id;
        CreationDate = creationDate;
        Users = users;
    }

    public Guid Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string Users { get; private set; }

    public ICollection<Message> Messages { get; set; }
}
