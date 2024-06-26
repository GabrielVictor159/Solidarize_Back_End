using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution;
using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Api.UseCases.MessageDiscution.CreateMessageDiscution;

public class CreateMessageDiscution
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly CreateMessageDiscutionPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly ICreateMessageDiscutionUseCase useCase;

    public CreateMessageDiscution
    (HttpRequestValidator validator, 
    CreateMessageDiscutionPresenter presenter, 
    NotificationMiddleware middleware, 
    ICreateMessageDiscutionUseCase useCase)
    {
        validator.AddValidator(new BodyValidator<CreateMessageDiscutionRequest>());
        validator.AddValidator(new AuthorizationValidator());

        this.httpRequestValidator = validator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("CreateMessageDiscution")]
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
            CreateMessageDiscutionRequest body = new();
            
            body = JsonConvert.DeserializeObject<CreateMessageDiscutionRequest>(requestBody!)!;
            
            var IdMessage = Guid.NewGuid();
            var attachedFiles = new List<AttachedFile>();
            body.Files.ForEach(e=>{
                attachedFiles.Add(new(Guid.NewGuid(),e.Item,e.Type,DateTime.Now,IdMessage));
            });

            useCase.Execute(new
            (
                new Domain.Models.Shipping.MessageDiscution(IdMessage,body.IdShipping,body.Message,idUser,DateTime.Now),
                attachedFiles
            ));

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
