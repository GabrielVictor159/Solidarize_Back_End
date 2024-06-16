using System.Runtime.Serialization;

namespace Solidarize.Domain.Enums;

public enum MessageFileType
{
    [EnumMember(Value ="Image/Jpeg")]
    ImageJpeg,
    [EnumMember(Value ="Image/Png")]
    ImagePng,
    [EnumMember(Value ="Video/Mp4")]
    VideoMp4,
    [EnumMember(Value ="Document")]
    Document 
}
