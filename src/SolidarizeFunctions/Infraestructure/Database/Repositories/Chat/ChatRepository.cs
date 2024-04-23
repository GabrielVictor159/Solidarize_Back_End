using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Chat;

namespace Solidarize.Infraestructure.Database.Repositories.Chat;

public class ChatRepository 
    : CRUDRepositoryPattern<Domain.Models.Chat.Chat, Entities.Chat.Chat>,
    IChatRepository
{
    public ChatRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
