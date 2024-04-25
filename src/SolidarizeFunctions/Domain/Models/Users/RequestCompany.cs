namespace Solidarize.Domain.Models.Users;

public class RequestCompany
{
    public RequestCompany(Guid id, string body, DateTime creationDate)
    {
        Id = id;
        Body = body;
        CreationDate = creationDate;
    }

    public Guid Id { get; set; }
    public string Body { get; set; }
    public DateTime CreationDate { get; set; }
}
