using System;
using System.Collections.Generic;

namespace Solidarize.Infraestructure.Database.Entities.Users
{
    public partial class Password
    {
        public Password()
        {
            Companies = new HashSet<Company>();
        }

        public Guid Id { get; set; }
        public DateTime LastDateModified { get; set; }
        public string LatestPasswords { get; set; }
        public string Encryption { get; set; }
        public int PasswordSize { get; set; }
        public int ComplexedSize { get; set; }
        public string PasswordValue { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
