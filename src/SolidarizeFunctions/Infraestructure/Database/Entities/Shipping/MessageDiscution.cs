using System;
using System.Collections.Generic;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Entities.Shipping
{
    public partial class MessageDiscution
    {
        public MessageDiscution()
        {
            AttachedFiles = new HashSet<AttachedFile>();
        }

        public Guid Id { get; set; }
        public Guid IdShipping { get; set; }
        public string Message { get; set; } = null!;
        public Guid? IdUser { get; set; }
        public DateTime CreationDate {get; set;}

        public virtual Shipping IdShippingNavigation { get; set; } = null!;
        public virtual Company? IdUserNavigation { get; set; }
        public virtual ICollection<AttachedFile> AttachedFiles { get; set; }
    }
}
