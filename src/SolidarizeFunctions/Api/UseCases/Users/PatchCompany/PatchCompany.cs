using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Validator.Http;
using Solidarize.Api.Filters;
using Solidarize.Application.UseCases.Users.PatchCompany;

namespace Solidarize.Api.UseCases.Users.PatchCompany;

public class PatchCompany
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly PatchCompanyPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IPatchCompanyUseCase useCase;

    public PatchCompany
    (HttpRequestValidator httpRequestValidator, 
    PatchCompanyPresenter presenter, 
    NotificationMiddleware middleware, 
    IPatchCompanyUseCase useCase)
    {
        httpRequestValidator.AddValidator(new BodyValidator<PatchCompanyRequest>());
        httpRequestValidator.AddValidator(new AuthorizationValidator());
        this.httpRequestValidator = httpRequestValidator;
        this.presenter = presenter;
        this.middleware = middleware;
        this.useCase = useCase;
    }

    [FunctionName("PatchCompany")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Anonymous, "patch", Route = null)] HttpRequest req,
        ILogger log)
    {
        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
         {
             try
             {
                 req.Body.Position = 0;
                 var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                 PatchCompanyRequest body = new();

                 body = JsonConvert.DeserializeObject<PatchCompanyRequest>(requestBody!)!;

                 useCase.Execute(
                    new 
                    (
                        Guid.Parse(httpRequestValidator.Claims.Where(e=>e.Type=="User_Id").First().Value),
                        body.Images,
                        body.Icon,
                        body.CompanyName,
                        body.Description,
                        body.LegalNature,
                        body.LastAccessDate,
                        body.LocationX,
                        body.LocationY,
                        body.CNPJ,
                        body.Address,
                        body.Telefone,
                        body.Password
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

