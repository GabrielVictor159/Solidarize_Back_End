using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Shipping.CreateShipping;

namespace Solidarize.Api.UseCases.Shipping.CreateShipping;

public class CreateShipping
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly CreateShippingPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly ICreateShippingUseCase useCase;

    public CreateShipping
    (HttpRequestValidator validator, 
    CreateShippingPresenter presenter, 
    NotificationMiddleware middleware, 
    ICreateShippingUseCase useCase)
    {
        validator.AddValidator(new BodyValidator<CreateShippingRequest>());
        validator.AddValidator(new AuthorizationValidator());

        this.httpRequestValidator = validator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("CreateShipping")]
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
            CreateShippingRequest body = new();
            
            body = JsonConvert.DeserializeObject<CreateShippingRequest>(requestBody!)!;

            useCase.Execute(new(idUser,body.IdUserDestination,body.Description,body.Name));
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
