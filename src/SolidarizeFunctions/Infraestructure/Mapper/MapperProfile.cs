using AutoMapper;
using Solidarize.Domain.Models.Chat;
using Solidarize.Domain.Models.Logs;
using Solidarize.Domain.Models.Shipping;
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
        CreateMap<Company, Database.Entities.Users.Company>()
        .ForMember(dest => dest.ShippingIdUserCreationNavigations, opt => opt.MapFrom(src => src.ShippingIdUserCreationNavigations))
        .ForMember(dest => dest.ShippingIdUserResponseNavigations, opt => opt.MapFrom(src => src.ShippingIdUserResponseNavigations))
        .ForMember(dest => dest.MessageDiscutions, opt => opt.MapFrom(src => src.MessageDiscutions))
        .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
        .ReverseMap();
        
        CreateMap<Password, Database.Entities.Users.Password>()
        .ForMember(dest => dest.Companies, opt => opt.MapFrom(src => src.Companies))
        .ReverseMap();

        CreateMap<Chat, Database.Entities.Chat.Chat>().ReverseMap();
        CreateMap<Message, Database.Entities.Chat.Message>().ReverseMap();
        CreateMap<RequestCompany, Database.Entities.Users.RequestCompany>().ReverseMap();
        CreateMap<Log, Database.Entities.Logs.Log>().ReverseMap();
        CreateMap<RequestRecoverPassword, Database.Entities.Users.RequestRecoverPassword>().ReverseMap();

        CreateMap<Shipping, Database.Entities.Shipping.Shipping>()
        .ForMember(dest => dest.IdUserCreationNavigation, opt => opt.MapFrom(src => src.IdUserCreationNavigation))
        .ForMember(dest => dest.IdUserResponseNavigation, opt => opt.MapFrom(src => src.IdUserResponseNavigation))
        .ForMember(dest=>dest.MessageDiscution, opt => opt.MapFrom(src=> src.MessageDiscution))
        .ReverseMap();

        CreateMap<MessageDiscution, Database.Entities.Shipping.MessageDiscution>()
        .ForMember(dest => dest.IdShippingNavigation, opt => opt.MapFrom(src => src.IdShippingNavigation))
        .ForMember(dest => dest.IdUserNavigation, opt => opt.MapFrom(src => src.IdUserNavigation))
        .ForMember(dest => dest.AttachedFiles, opt => opt.MapFrom(src => src.AttachedFiles))
        .ReverseMap();

        CreateMap<AttachedFile, Database.Entities.Shipping.AttachedFile>()
        .ForMember(dest => dest.IdMessageDiscutionNavigation, opt => opt.MapFrom(src => src.IdMessageDiscutionNavigation))
        .ReverseMap();
    }
}
