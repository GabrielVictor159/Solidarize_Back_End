using System;
using System.Collections.Generic;
using Solidarize.Infraestructure.Database.Entities.Users;

namespace Solidarize.Infraestructure.Database.Entities.Chat
{
    public partial class Message
    {
        public Guid Id { get; set; }
        public Guid IdChat { get; set; }
        public Guid IdUser { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreationDate { get; set; }
        public string SeenUsers { get; set; }
        public string DataType { get; set; }

        public virtual Chat Chat{ get; set; }
        public virtual Company Company { get; set; }
    }
}
