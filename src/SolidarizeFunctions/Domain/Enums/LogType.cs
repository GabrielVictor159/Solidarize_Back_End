using System.Runtime.Serialization;

namespace Solidarize.Domain.Enums;

public enum LogType
{
    [EnumMember(Value ="ERROR")]
    ERROR,
    [EnumMember(Value ="INFO")]
    INFO,
    [EnumMember(Value ="PROCESS")]
    PROCESS
}
