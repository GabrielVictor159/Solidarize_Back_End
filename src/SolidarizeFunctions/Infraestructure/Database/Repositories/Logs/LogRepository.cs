using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Solidarize.Application.Interfaces.Repositories;
using Solidarize.Application.Interfaces.Repositories.Logs;

namespace Solidarize.Infraestructure.Database.Repositories.Logs;

public class LogRepository
    : CRUDRepositoryPattern<Domain.Models.Logs.Log, Entities.Logs.Log>,
    ILogRepository
{
    public LogRepository(Context context, IMapper mapper) : base(context, mapper)
    {
    }
}
