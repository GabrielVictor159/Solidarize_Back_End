
using Newtonsoft.Json;
using Solidarize.Domain.Validator.Users;

namespace Solidarize.Domain.Models.Users;

public class Password : Entity<Password, PasswordValidator>
{
    public Password(Guid id, DateTime lastDateModified, string latestPasswords, string encryption, int passwordSize, int complexedSize, string passwordValue)
        : base(new PasswordValidator())
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

    public ICollection<Company>? Companies { get; set; }

    public void SetPasswordValue(string NewPassword, string Encryption, int PasswordSize, int ComplexedSize)
    {
        var latestPasswordsArray = JsonConvert.DeserializeObject<List<string>>(LatestPasswords);
        latestPasswordsArray!.Add(this.PasswordValue);
        this.PasswordValue = NewPassword;
        this.Encryption = Encryption;
        this.PasswordSize = PasswordSize;
        this.ComplexedSize = ComplexedSize;
        this.LastDateModified = DateTime.Now;
        this.LatestPasswords = JsonConvert.SerializeObject(latestPasswordsArray);
    }
}
