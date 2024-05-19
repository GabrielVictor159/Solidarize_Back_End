using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Users.GetMyInformation;

namespace Solidarize.Api.UseCases.Users.GetMyInformation;

public class GetMyInformation
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly GetMyInformationPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IGetMyInformationUseCase useCase;

    public GetMyInformation
    (HttpRequestValidator httpRequestValidator, 
    GetMyInformationPresenter presenter, 
    NotificationMiddleware middleware, 
    IGetMyInformationUseCase useCase)
    {
        httpRequestValidator.AddValidator(new AuthorizationValidator());
        this.httpRequestValidator = httpRequestValidator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("GetMyInformation")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
        ILogger log)
    {
        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
         {
             try
             {
                 useCase.Execute(
                    new 
                    (
                        Guid.Parse(httpRequestValidator.Claims.Where(e=>e.Type=="User_Id").First().Value)
                    ));

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
