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

namespace Solidarize.Api.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompany
{
    private HttpRequestValidator httpRequestValidator { get; set; }
    private readonly RequestRegisterCompanyPresenter presenter;
    private readonly NotificationMiddleware middleware;
    private readonly IRequestRegisterCompanyUseCase requestRegisterCompanyUseCase;
    public RequestRegisterCompany
    (HttpRequestValidator validator,
    RequestRegisterCompanyPresenter RequestRegisterCompanyPresenter,
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
            req.Body.Position = 0;
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            RequestRegisterCompanyRequest body = new();
            
            try
            {
                body = JsonConvert.DeserializeObject<RequestRegisterCompanyRequest>(requestBody!)!;
            }
            catch { }
            requestRegisterCompanyUseCase.Execute(new(body.CompanyName, body.Description, body.LegalNature, body.LocationX, body.LocationY, body.CNPJ, body.Address, body.Email, body.Password, body.Telefone));
            return presenter.ViewModel;
        });
    }
}

