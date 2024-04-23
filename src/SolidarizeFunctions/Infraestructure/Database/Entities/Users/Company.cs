using System;
using System.Collections.Generic;
using Solidarize.Infraestructure.Database.Entities.Chat;

namespace Solidarize.Infraestructure.Database.Entities.Users
{
    public partial class Company
    {
        public string CompanyName { get; set; }
        public string Images { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public int LegalNature { get; set; }
        public string LocationX { get; set; }
        public string LocationY { get; set; }
        public bool Banned { get; set; }
        public DateTime? BanDate { get; set; }
        public DateTime? CreationDate { get; set; }
        public DateTime? LastAccessDate { get; set; }
        public string Cnpj { get; set; }
        public string Address { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public Guid Idpassword { get; set; }

        public virtual Password Password { get; set; }
    }
}
