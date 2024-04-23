namespace Solidarize.Domain.Models.Users;

public class Password
{
    public Password(Guid id, DateTime lastDateModified, string latestPasswords, string encryption, int passwordSize, int complexedSize, string passwordValue)
    {
        Id = id;
        LastDateModified = lastDateModified;
        LatestPasswords = latestPasswords;
        Encryption = encryption;
        PasswordSize = passwordSize;
        ComplexedSize = complexedSize;
        PasswordValue = passwordValue;
    }

    public Guid Id { get; private set; }
    public DateTime LastDateModified { get; private set; }
    public string LatestPasswords { get; private set; }
    public string Encryption { get; private set; }
    public int PasswordSize { get; private set; }
    public int ComplexedSize { get; private set; }
    public string PasswordValue { get; private set; }

    public ICollection<Company> Companies { get; set; }
}
