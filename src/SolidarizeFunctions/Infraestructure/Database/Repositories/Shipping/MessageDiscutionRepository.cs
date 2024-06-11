using AutoMapper;
using Solidarize.Application.Interfaces.Repositories.Shipping;

namespace Solidarize.Infraestructure.Database.Repositories.Shipping;

public class MessageDiscutionRepository
: CRUDRepositoryPattern<Domain.Models.Shipping.MessageDiscution, Entities.Shipping.MessageDiscution>,
IMessageDiscutionRepository
{
    public MessageDiscutionRepository(IMapper mapper) : base(mapper)
    {
    }
}
