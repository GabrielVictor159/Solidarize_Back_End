using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.GetProfile;

public class GetProfileResponse
{
    public GetProfileResponse(Company? company)
    {
        this.company = company;
    }

    public Company? company {get; private set;}
}
