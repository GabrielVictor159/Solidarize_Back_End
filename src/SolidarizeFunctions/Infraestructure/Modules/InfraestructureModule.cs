using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;
using Solidarize.Infraestructure.Database;
using Solidarize.Infraestructure.Mapper;
using Solidarize.Infraestructure.Services;

namespace Solidarize.Infraestructure.Modules;

public class InfraestructureModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        DataAccess(services);
        Mapper(services);
    }
    private void DataAccess(IServiceCollection services)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        services.AddSingleton(new Context());
    }
    private void Mapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(MapperProfile).Assembly);
    }

}
