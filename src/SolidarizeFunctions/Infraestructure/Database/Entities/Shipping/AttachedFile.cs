using System;
using System.Collections.Generic;
using Solidarize.Domain.Enums;

namespace Solidarize.Infraestructure.Database.Entities.Shipping
{
    public partial class AttachedFile
    {
        public Guid Id { get; set; }
        public string Item { get; set; } = null!;
        public MessageFileType Type { get; set; }
        public DateTime CreationDate { get; set; }
        public Guid IdMessageDiscution { get; set; }

        public virtual MessageDiscution IdMessageDiscutionNavigation { get; set; } = null!;
    }
}
