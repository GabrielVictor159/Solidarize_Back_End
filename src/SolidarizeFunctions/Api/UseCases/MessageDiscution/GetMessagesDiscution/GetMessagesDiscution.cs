using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Shipping.GetMessagesDiscution;

namespace Solidarize.Api.UseCases.MessageDiscution.GetMessagesDiscution;

public class GetMessagesDiscution
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly GetMessagesDiscutionPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IGetMessagesDiscutionUseCase useCase;

    public GetMessagesDiscution
    (HttpRequestValidator validator, 
    GetMessagesDiscutionPresenter presenter, 
    NotificationMiddleware middleware, 
    IGetMessagesDiscutionUseCase useCase)
    {
        validator.AddValidator(new BodyValidator<GetMessagesDiscutionRequest>());
        validator.AddValidator(new AuthorizationValidator());

        this.httpRequestValidator = validator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("GetMessagesDiscution")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
        ILogger log)
    {
        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
        {
            try
            {
            req.Body.Position = 0;
            var idUser = Guid.Parse(httpRequestValidator.Claims.Where(e=>e.Type=="User_Id").First().Value);
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            GetMessagesDiscutionRequest body = new();
            
            body = JsonConvert.DeserializeObject<GetMessagesDiscutionRequest>(requestBody!)!;
            
            useCase.Execute(new(idUser,body.IdShipping));

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
