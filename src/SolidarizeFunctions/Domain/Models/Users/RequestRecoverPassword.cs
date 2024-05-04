namespace Solidarize.Domain.Models.Users;

public class RequestRecoverPassword
{
    public RequestRecoverPassword(Guid id, string body, DateTime creationDate)
    {
        Id = id;
        Body = body;
        CreationDate = creationDate;
    }

    public Guid Id { get; private set; }
    public string Body { get; private set; } = "";
    public DateTime CreationDate { get; private set; }
}
