using System;
using System.Collections.Generic;

namespace Solidarize.Infraestructure.Database.Entities.Chat
{
    public partial class Chat
    {
        public Chat()
        {
            Messages = new HashSet<Message>();
        }

        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Users { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
