using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Users.GetOngs;

namespace Solidarize.Api.UseCases.Users.GetOngs;

public class GetOngs
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly GetOngsPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IGetOngsUseCase useCase;

    public GetOngs
    (HttpRequestValidator httpRequestValidator, 
    GetOngsPresenter presenter, 
    NotificationMiddleware middleware, 
    IGetOngsUseCase useCase)
    {
        this.httpRequestValidator = httpRequestValidator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("GetOngs")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
         {
             try
             {
                 useCase.Execute(
                    new ());

                 return presenter.ViewModel;
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Occurring an error: {ex.Message ?? ex.InnerException?.Message}, stacktrace: {ex.StackTrace}");
                 return new StatusCodeResult(StatusCodes.Status500InternalServerError);
             }
         });
    }
}
