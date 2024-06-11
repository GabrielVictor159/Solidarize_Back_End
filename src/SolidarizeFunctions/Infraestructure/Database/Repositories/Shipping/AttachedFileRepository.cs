using AutoMapper;
using Solidarize.Application.Interfaces.Repositories.Shipping;

namespace Solidarize.Infraestructure.Database.Repositories.Shipping;

public class AttachedFileRepository
: CRUDRepositoryPattern<Domain.Models.Shipping.AttachedFile, Entities.Shipping.AttachedFile>,
IAttachedFileRepository
{
    public AttachedFileRepository(IMapper mapper) : base(mapper)
    {
    }
}
