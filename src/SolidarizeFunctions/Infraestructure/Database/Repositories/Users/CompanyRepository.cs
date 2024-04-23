using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Infraestructure.Database.Repositories.Users;

public class CompanyRepository 
    : CRUDRepositoryPattern<Domain.Models.Users.Company, Entities.Users.Company>,
    ICompanyRepository
{
    public CompanyRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
