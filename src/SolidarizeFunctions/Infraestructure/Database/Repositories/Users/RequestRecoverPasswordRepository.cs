using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Infraestructure.Database.Repositories.Users;

public class RequestRecoverPasswordRepository
    : CRUDRepositoryPattern<Domain.Models.Users.RequestRecoverPassword, Entities.Users.RequestRecoverPassword>,
    IRequestRecoverPasswordRepository
{
    public RequestRecoverPasswordRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
