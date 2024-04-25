using AutoMapper;
using Solidarize.Domain.Models.Chat;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Infraestructure.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        MapDomains();
    }
    public void MapDomains()
    {
        CreateMap<Company, Database.Entities.Users.Company>().ReverseMap();
        CreateMap<Password, Database.Entities.Users.Password>().ReverseMap();
        CreateMap<Chat, Database.Entities.Chat.Chat>().ReverseMap();
        CreateMap<Message, Database.Entities.Chat.Message>().ReverseMap();
        CreateMap<RequestCompany, Database.Entities.Users.RequestCompany>().ReverseMap();
        CreateMap<Log, Database.Entities.Logs.Log>().ReverseMap();
    }
}
