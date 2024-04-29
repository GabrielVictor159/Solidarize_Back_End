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
using Solidarize.Application.Interfaces.Repositories.Chat;
using Solidarize.Domain.Models.Chat;
using Solidarize.Api.Filters;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany;
using Solidarize.Application.Bundaries;

namespace Solidarize.Api.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompany
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly IOutputPort<Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse> presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IRequestRegisterCompanyUseCase requestRegisterCompanyUseCase;
    public RequestRegisterCompany
    (HttpRequestValidator validator,
    IOutputPort<Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse> RequestRegisterCompanyPresenter,
    NotificationMiddleware notificationMiddleware,
    IRequestRegisterCompanyUseCase requestRegisterCompanyUseCase)
    {
        validator.AddValidator(new BodyValidator<RequestRegisterCompanyRequest>());
        this.httpRequestValidator = validator;
        this.presenter = RequestRegisterCompanyPresenter;
        this.middleware = notificationMiddleware;
        this.requestRegisterCompanyUseCase = requestRegisterCompanyUseCase;
    }

    [FunctionName("RequestRegisterCompany")]
    public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
    {

        return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
        {
            try
            {
            req.Body.Position = 0;
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RequestRegisterCompanyRequest body = new();
            
            body = JsonConvert.DeserializeObject<RequestRegisterCompanyRequest>(requestBody!)!;

            requestRegisterCompanyUseCase.Execute(new(body.CompanyName, body.Description, body.LegalNature, body.LocationX, body.LocationY, body.CNPJ, body.Address, body.Email, body.Password, body.Telefone));
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

