
using Solidarize.Application.Interfaces.Repositories.Shipping;

namespace Solidarize.Application.UseCases.Shipping.GetMyShippings.Handlers;

public class GetMyShippingsHandler : Handler<GetMyShippingsRequest>
{
    private readonly IShippingRepository shippingRepository;

    public GetMyShippingsHandler(IShippingRepository shippingRepository)
    {
        this.shippingRepository = shippingRepository;
    }

    public override void ProcessRequest(GetMyShippingsRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Shippings = shippingRepository.GetByFilter(e=>e.IdUserCreation==request.IdUser || e.IdUserResponse ==request.IdUser);
        if(request.Id!=null)
        {
            request.Shippings = request.Shippings.Where(e=>e.Id==request.Id).ToList();
        }

        if(request.Name!=null)
        {
            request.Shippings = request.Shippings.Where(e=>(e.Name==null?"":e.Name).ToLower().Contains(request.Name.ToLower())).ToList();
        }


        sucessor?.ProcessRequest(request);
    }
}
