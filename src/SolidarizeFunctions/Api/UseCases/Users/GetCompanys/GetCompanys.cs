using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Filters;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.UseCases.Users.GetCompanys;

namespace Solidarize.Api.UseCases.Users.GetCompanys;

public class GetCompanys
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly GetCompanysPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IGetCompanysUseCase useCase;
    public GetCompanys
    (HttpRequestValidator validator,
    GetCompanysPresenter presenter,
    NotificationMiddleware notificationMiddleware,
    IGetCompanysUseCase confirmRegisterCompanyUseCase)
    {
        validator.AddValidator(new BodyValidator<Solidarize.Api.UseCases.Users.GetCompanys.GetCompanysRequest>());
        validator.AddValidator(new AuthorizationValidator());
        this.httpRequestValidator = validator;
        this.presenter = presenter;
        this.middleware = notificationMiddleware;
        this.useCase = confirmRegisterCompanyUseCase;
    }
    [FunctionName("GetCompanys")]
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
           Solidarize.Api.UseCases.Users.GetCompanys.GetCompanysRequest body = new();

           body = JsonConvert.DeserializeObject<Solidarize.Api.UseCases.Users.GetCompanys.GetCompanysRequest>(requestBody!)!;

           useCase.Execute(new(body.IdCompany,body.CompanyName,body.LegalNature,body.Cnpj,body.Telefone,body.Email));
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
