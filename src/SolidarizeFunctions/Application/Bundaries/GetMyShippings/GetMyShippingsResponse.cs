using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.Bundaries.GetMyShippings;

public class GetMyShippingsResponse
{
    public GetMyShippingsResponse(List<Shipping> shippings)
    {
        Shippings = shippings;
    }

    public List<Shipping> Shippings {get; private set;} = new();
}
