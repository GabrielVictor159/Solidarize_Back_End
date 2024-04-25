using System;
using System.Collections.Generic;

namespace Solidarize.Infraestructure.Database.Entities.Users
{
    public partial class RequestCompany
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
