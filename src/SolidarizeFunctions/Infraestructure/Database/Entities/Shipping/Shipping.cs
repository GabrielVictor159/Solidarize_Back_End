using System;
using System.Collections.Generic;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Entities.Shipping
{
    public partial class Shipping
    {
        public DateTime CreationDate { get; set; }
        public Guid IdUserCreation { get; set; }
        public Guid IdUserResponse { get; set; }
        public string? Description { get; set; }
        public string? Name { get; set; }
        public Guid Id { get; set; }

        public virtual Company IdUserCreationNavigation { get; set; } = null!;
        public virtual Company IdUserResponseNavigation { get; set; } = null!;
        public virtual ICollection<MessageDiscution> MessageDiscution { get; set; } = null!;
    }
}
