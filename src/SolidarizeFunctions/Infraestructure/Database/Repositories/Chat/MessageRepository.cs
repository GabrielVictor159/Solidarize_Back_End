using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Chat;

namespace Solidarize.Infraestructure.Database.Repositories.Chat;

public class MessageRepository 
    : CRUDRepositoryPattern<Domain.Models.Chat.Message, Entities.Chat.Message>,
    IMessageRepository
{
    public MessageRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
