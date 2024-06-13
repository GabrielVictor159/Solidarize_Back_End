using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.Bundaries.CreateShipping;

public class CreateShippingResponse
{
    public CreateShippingResponse(Shipping? shipping)
    {
        Shipping = shipping;
    }

    public Shipping? Shipping {get; private set;}
}
