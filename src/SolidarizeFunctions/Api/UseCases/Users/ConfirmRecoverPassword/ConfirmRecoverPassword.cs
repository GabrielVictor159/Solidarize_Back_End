using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.Bundaries;
using Solidarize.Api.Filters;
using Solidarize.Application.UseCases.Users.ConfirmRecoverPassword;

namespace Solidarize.Api.UseCases.Users.ConfirmRecoverPassword;

public class ConfirmRecoverPassword
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly IOutputPort<Application.Bundaries.ConfirmRecoverPassword.ConfirmRecoverPasswordResponse> presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IConfirmRecoverPasswordUseCase useCase;

    public ConfirmRecoverPassword
    (HttpRequestValidator validator, 
    IOutputPort<Application.Bundaries.ConfirmRecoverPassword.ConfirmRecoverPasswordResponse> presenter, 
    NotificationMiddleware middleware, 
    IConfirmRecoverPasswordUseCase useCase)
    {
        validator.AddValidator(new BodyValidator<ConfirmRecoverPasswordRequest>());
        this.httpRequestValidator = validator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("ConfirmRecoverPassword")]
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
            ConfirmRecoverPasswordRequest body = new();
            
            body = JsonConvert.DeserializeObject<ConfirmRecoverPasswordRequest>(requestBody!)!;

            useCase.Execute(new(body.IdRequest, body.NewPassword!));
            return presenter.ViewModel;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Occurring an error: {ex.Message ?? ex.InnerException?.Message}, stacktrace: {ex.StackTrace}");
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        });
    }
}
