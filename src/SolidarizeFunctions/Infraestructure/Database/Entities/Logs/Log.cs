using System;
using System.Collections.Generic;
using Solidarize.Domain.Enums;

namespace Solidarize.Infraestructure.Database.Entities.Logs
{
    public partial class Log
    {
        public Guid Id { get; set; }
        public LogType Type { get; set; }
        public UseCases? UseCase { get; set; }
        public string Message { get; set; } = null!;
        public DateTime LogDate { get; set; }
    }
}
