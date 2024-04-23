using Solidarize.Domain.Models.Users;

namespace Solidarize.Domain.Models.Chat;

public class Message
{
    public Message(Guid id, Guid idChat, Guid idUser, string messageBody, DateTime creationDate, string seenUsers, string dataType)
    {
        Id = id;
        IdChat = idChat;
        IdUser = idUser;
        MessageBody = messageBody;
        CreationDate = creationDate;
        SeenUsers = seenUsers;
        DataType = dataType;
    }

    public Guid Id { get; private set; }
    public Guid IdChat { get; private set; }
    public Guid IdUser { get; private set; }
    public string MessageBody { get; private set; }
    public DateTime CreationDate { get; private set; }
    public string SeenUsers { get; private set; }
    public string DataType { get; private set; }

    public Chat Chat { get; set; }
    public Company Company { get; set; }
}
