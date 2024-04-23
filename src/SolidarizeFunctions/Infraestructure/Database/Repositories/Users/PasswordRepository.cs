using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Infraestructure.Database.Repositories.Users;

public class PasswordRepository
    : CRUDRepositoryPattern<Domain.Models.Users.Password, Entities.Users.Password>,
    IPasswordRepository
{
    public PasswordRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
