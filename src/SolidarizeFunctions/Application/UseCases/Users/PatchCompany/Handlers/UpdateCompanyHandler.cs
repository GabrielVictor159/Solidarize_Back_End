using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers;

public class UpdateCompanyHandler: Handler<PatchCompanyRequest>
{
    private readonly UpdateSubHandlersFactory updateSubHandlersFactory;
    private readonly ICompanyRepository companyRepository;
    private readonly INotificationService notificationService;

    public UpdateCompanyHandler
    (UpdateSubHandlersFactory updateSubHandlersFactory, 
    ICompanyRepository companyRepository, 
    INotificationService notificationService)
    {
        this.updateSubHandlersFactory = updateSubHandlersFactory;
        this.companyRepository = companyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        var NewCompany = new 
        Company
        (
            request.CompanyName==null?request.Company!.CompanyName:request.CompanyName,
            request.Company!.Images,
            request.Company.Icon,
            request.Description==null?request.Company!.Description:request.Description,
            request.LegalNature==null?request.Company!.LegalNature:request.LegalNature.Value,
            request.LocationX==null?request.Company!.LocationX:request.LocationX,
            request.LocationY==null?request.Company!.LocationY:request.LocationY,
            request.Company.Banned,
            request.Company.BanDate,
            request.Company.CreationDate,
            request.LastAccessDate==null?request.Company!.LastAccessDate:request.LastAccessDate,
            request.CNPJ==null?request.Company!.Cnpj:request.CNPJ,
            request.Address==null?request.Company!.Address:request.Address,
            request.Telefone==null?request.Company!.Telefone:request.Telefone,
            request.Company.Email,
            request.Company.Id,
            request.Company.Idpassword,
            null
        );
        request.Company = NewCompany;

        updateSubHandlersFactory.ProcessRequest(request);

        if(!request.Company.IsValid)
        {
            notificationService.AddNotifications(request.Company.ValidationResult);
            return;
        }

        companyRepository.Update(request.Company);
        
        sucessor?.ProcessRequest(request);
    }
}
