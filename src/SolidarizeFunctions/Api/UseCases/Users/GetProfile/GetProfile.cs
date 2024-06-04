using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Users.GetProfile;

namespace Solidarize.Api.UseCases.Users.GetProfile;

public class GetProfile
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly GetProfilePresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IGetProfileUseCase useCase;
    public GetProfile
    (HttpRequestValidator httpRequestValidator, 
    GetProfilePresenter presenter, 
    NotificationMiddleware middleware,
    IGetProfileUseCase useCase)
    {
        this.httpRequestValidator = httpRequestValidator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("GetProfile")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
         {
             try
             {
                 req.Body.Position = 0;
                 var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                 GetProfileRequest body = new();

                 body = JsonConvert.DeserializeObject<GetProfileRequest>(requestBody!)!;

                 useCase.Execute(new(body.Id));
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
