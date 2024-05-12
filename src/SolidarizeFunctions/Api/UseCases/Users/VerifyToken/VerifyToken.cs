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

namespace Solidarize.Api.UseCases.Users.VerifyToken;
public class VerifyToken
{
        private HttpRequestValidator httpRequestValidator { get; set; }
        private readonly NotificationMiddleware middleware;

        public VerifyToken
        (HttpRequestValidator httpRequestValidator, 
        NotificationMiddleware middleware)
        {
            httpRequestValidator.AddValidator(new AuthorizationValidator());
            this.httpRequestValidator = httpRequestValidator;
            this.middleware = middleware;
        }

        [FunctionName("VerifyToken")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            return await middleware.InvokeAsync(req, log, httpRequestValidator, async () =>
         {
             try
             {
                 return new OkResult();
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"Occurring an error: {ex.Message ?? ex.InnerException?.Message}, stacktrace: {ex.StackTrace}");
                 return new StatusCodeResult(StatusCodes.Status500InternalServerError);
             }
         });
        }
}
