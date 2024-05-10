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
using Solidarize.Application.Bundaries;
using Solidarize.Api.Filters;
using Solidarize.Application.UseCases.Users.Login;

namespace Solidarize.Api.UseCases.Users.Login;

public class Login
{
     private HttpRequestValidator httpRequestValidator { get; set; }
        private readonly IOutputPort<Application.Bundaries.RecoverPassword.RecoverPasswordResponse> presenter;
        private readonly NotificationMiddleware middleware;
        private readonly ILoginUseCase useCase;

        public Login
        (HttpRequestValidator httpRequestValidator, 
        IOutputPort<Application.Bundaries.RecoverPassword.RecoverPasswordResponse> presenter, 
        NotificationMiddleware middleware, 
        ILoginUseCase useCase)
        {
            httpRequestValidator.AddValidator(new BodyValidator<LoginRequest>());
            this.httpRequestValidator = httpRequestValidator;
            this.presenter = presenter;
            this.middleware = middleware;
            this.useCase = useCase;
        }

        [FunctionName("Login")]
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
                 LoginRequest body = new();

                 body = JsonConvert.DeserializeObject<LoginRequest>(requestBody!)!;

                 useCase.Execute(new(body.Email, body.Password));
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
