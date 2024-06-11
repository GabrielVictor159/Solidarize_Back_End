using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.GetCompanys.Handlers;

public class SearchCompaniesHandler : Handler<GetCompanysRequest>
{
    private readonly ICompanyRepository companyRepository;

    public SearchCompaniesHandler(ICompanyRepository companyRepository)
    {
        this.companyRepository = companyRepository;
    }

    public override void ProcessRequest(GetCompanysRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.Companies = companyRepository.GetByFilter(e =>
            (request.IdCompany != null ? e.Id.Equals(request.IdCompany) : true) &&
            (request.CompanyName != null ? e.CompanyName.ToLower().Contains(request.CompanyName.ToLower()) : true) &&
            (request.LegalNature != null ? e.LegalNature.Equals(request.LegalNature) : true) &&
            (request.Cnpj != null ? e.Cnpj.Equals(request.Cnpj) : true) &&
            (request.Telefone != null ? e.Telefone.Equals(request.Telefone) : true) &&
            (request.Email != null ? e.Email.Equals(request.Email) : true)
        );
        sucessor?.ProcessRequest(request);
    }
}
