using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Infraestructure.Database.Repositories.Users;

public class RequestCompanyRepository
    : CRUDRepositoryPattern<Domain.Models.Users.RequestCompany, Entities.Users.RequestCompany>,
    IRequestCompanyRepository
{
    public RequestCompanyRepository(DbContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
