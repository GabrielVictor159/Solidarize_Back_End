using System;
using System.Collections.Generic;

namespace Solidarize.Infraestructure.Database.Entities.Public
{
    public partial class DeleteItem
    {
        public DateTime CreationDate { get; set; }
        public string Body { get; set; } = null!;
        public string Entity { get; set; } = null!;
        public Guid Id { get; set; }
    }
}
