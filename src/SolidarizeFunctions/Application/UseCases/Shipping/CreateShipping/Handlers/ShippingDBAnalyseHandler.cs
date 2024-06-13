using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Infraestructure.Database.Repositories.Shipping;

namespace Solidarize.Application.UseCases.Shipping.CreateShipping.Handlers;

public class ShippingDBAnalyseHandler : Handler<CreateShippingRequest>
{
    private readonly IShippingRepository shippingRepository;
    private readonly INotificationService notificationService;
    private readonly ICompanyRepository companyRepository;

    public ShippingDBAnalyseHandler(IShippingRepository shippingRepository, INotificationService notificationService, ICompanyRepository companyRepository)
    {
        this.shippingRepository = shippingRepository;
        this.notificationService = notificationService;
        this.companyRepository = companyRepository;
    }

    public override void ProcessRequest(CreateShippingRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        var shippingsDay = shippingRepository.GetByFilter(e=>
        e.IdUserCreation==request.ShippingComunications!.IdUserCreation 
        && e.IdUserResponse==request.ShippingComunications!.IdUserResponse
        && (e.CreationDate-DateTime.Now).TotalHours<24);

        if(shippingsDay.Count>=10)
        {
            notificationService.AddNotification("Many requests","O Limite de doações para a mesma pessoa é 10 por dia.");
            return;
        }

        var shippingName = shippingRepository.GetByFilter(e=>
        e.IdUserCreation==request.ShippingComunications!.IdUserCreation 
        && e.IdUserResponse==request.ShippingComunications!.IdUserResponse
        && (e.Name==null?"":e.Name).ToLower().Equals((request.ShippingComunications.Name==null?"":request.ShippingComunications.Name).ToLower()));

        if(shippingName.Count>0)
        {
            notificationService.AddNotification("Shipping Existing","Ja existe uma doação com esse mesmo nome.");
            return;
        }

        var userDestination = companyRepository.GetOne(request.IdUserDestination);

        if(userDestination==null)
        {
            notificationService.AddNotification("User not found","Não foi encontrado o usuario de destino.");
            return;
        }

        sucessor?.ProcessRequest(request);
    }
}
