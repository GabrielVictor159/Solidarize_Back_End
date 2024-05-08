

using System.Runtime.Serialization;

namespace Solidarize.Domain.Enums;

public enum UseCases
{
    [EnumMember(Value ="RequestRegisterCompany")]
    RequestRegisterCompany,
    [EnumMember(Value ="ConfirmRegisterCompany")]
    ConfirmRegisterCompany,
    [EnumMember(Value ="RecoverPassword")]
    RecoverPassword,
    [EnumMember(Value ="ConfirmRecoverPassword")]
    ConfirmRecoverPassword

}
