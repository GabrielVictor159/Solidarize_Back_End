using Solidarize.Domain.Enums;

namespace Solidarize.Domain.Models.Logs;

public class Log
{

    public Guid Id { get; private set; }
    public LogType Type { get; private set; }
    public UseCases? UseCase { get; private set; }
    public string Message { get; private set; } = null!;
    public DateTime LogDate { get; private set; }
    public Log(Guid id, LogType type, UseCases? useCase, string message, DateTime logDate)
    {
        Id = id;
        Type = type;
        UseCase = useCase;
        Message = message;
        LogDate = logDate;
    }
}
