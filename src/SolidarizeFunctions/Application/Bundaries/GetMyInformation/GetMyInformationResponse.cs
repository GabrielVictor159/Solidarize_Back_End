using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.GetMyInformation;

public class GetMyInformationResponse
{
    public GetMyInformationResponse(Company? company)
    {
        this.company = company;
    }

    public Company? company {get; private set;}
}
