using Solidarize.Application.Interfaces.Repositories.Shipping;

namespace Solidarize.Application.UseCases.Shipping.CreateShipping.Handlers;

public class CreateShippingHandler : Handler<CreateShippingRequest>
{
    private readonly IShippingRepository shippingRepository;

    public CreateShippingHandler(IShippingRepository shippingRepository)
    {
        this.shippingRepository = shippingRepository;
    }

    public override void ProcessRequest(CreateShippingRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        shippingRepository.Add(request.ShippingComunications!);
        request.Shipping = request.ShippingComunications;
        
        sucessor?.ProcessRequest(request);
    }
}
