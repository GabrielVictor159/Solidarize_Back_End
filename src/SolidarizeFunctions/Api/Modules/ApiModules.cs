
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Interface;
using Solidarize.Api.Validator.Http;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;

namespace Solidarize.Api.Modules;

public class ApiModule : Module
{
     public override void Configure(IServiceCollection services)
    {
        services.AddSingleton(new HttpRequestValidator());
    }

}
