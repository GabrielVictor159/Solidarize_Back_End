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
using Solidarize.Application.UseCases.Users.ConfirmRegisterCompany;
using Solidarize.Application.Bundaries;
using Solidarize.Api.UseCases.Users.ConfirmRegisterCompany;
namespace SolidarizeFunctions
{
    public class ConfirmRegisterCompany
    {
        private HttpRequestValidator httpRequestValidator { get; set; }
        private readonly ConfirmRegisterCompanyPresenter presenter;
        private readonly NotificationMiddleware middleware;
        private readonly IConfirmRegisterCompanyUseCase useCase;
        public ConfirmRegisterCompany
        (HttpRequestValidator validator,
        ConfirmRegisterCompanyPresenter presenter,
        NotificationMiddleware notificationMiddleware,
        IConfirmRegisterCompanyUseCase confirmRegisterCompanyUseCase)
        {
            validator.AddValidator(new BodyValidator<Solidarize.Api.UseCases.Users.ConfirmRegisterCompany.ConfirmRegisterCompanyRequest>());
            this.httpRequestValidator = validator;
            this.presenter = presenter;
            this.middleware = notificationMiddleware;
            this.useCase = confirmRegisterCompanyUseCase;
        }
        [FunctionName("ConfirmRegisterCompany")]
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
               Solidarize.Api.UseCases.Users.ConfirmRegisterCompany.ConfirmRegisterCompanyRequest body = new();

               body = JsonConvert.DeserializeObject<Solidarize.Api.UseCases.Users.ConfirmRegisterCompany.ConfirmRegisterCompanyRequest>(requestBody!)!;

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
}
