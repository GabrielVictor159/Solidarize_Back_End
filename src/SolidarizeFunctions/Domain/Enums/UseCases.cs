

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
    ConfirmRecoverPassword,
    [EnumMember(Value ="Login")]
    Login,
    [EnumMember(Value ="PatchCompany")]
    PatchCompany,
    [EnumMember(Value ="GetMyInformation")]
    GetMyInformation,
    [EnumMember(Value ="GetProfile")]
    GetProfile,
    [EnumMember(Value ="GetAllUsers")]
    GetAllUsers

}
