using System;
using System.Collections.Generic;
using Solidarize.Domain.Enums;
using Solidarize.Infraestructure.Database.Entities.Chat;
using Solidarize.Infraestructure.Database.Entities.Shipping;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.

namespace Solidarize.Infraestructure.Database.Entities.Users
{
    public partial class Company
    {
        public Company()
        {
            MessageDiscutions = new HashSet<MessageDiscution>();
            ShippingIdUserCreationNavigations = new HashSet<Shipping.Shipping>();
            ShippingIdUserResponseNavigations = new HashSet<Shipping.Shipping>();
        }
        public string CompanyName { get; set; }
        public string Images { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public LegalNature LegalNature { get; set; }
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
        public virtual ICollection<MessageDiscution> MessageDiscutions { get; set; }
        public virtual ICollection<Shipping.Shipping> ShippingIdUserCreationNavigations { get; set; }
        public virtual ICollection<Shipping.Shipping> ShippingIdUserResponseNavigations { get; set; }
    }
}
