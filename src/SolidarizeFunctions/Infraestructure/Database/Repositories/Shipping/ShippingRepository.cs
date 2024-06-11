using AutoMapper;
using Solidarize.Application.Interfaces.Repositories.Shipping;

namespace Solidarize.Infraestructure.Database.Repositories.Shipping;

public class ShippingRepository
: CRUDRepositoryPattern<Domain.Models.Shipping.Shipping, Entities.Shipping.Shipping>,
IShippingRepository
{
    public ShippingRepository(IMapper mapper) : base(mapper)
    {
    }
}
