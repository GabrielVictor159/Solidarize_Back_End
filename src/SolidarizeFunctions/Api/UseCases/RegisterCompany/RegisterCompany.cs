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
using Solidarize.Api.UseCases.RegisterCompany;
using Solidarize.Application.Interfaces.Repositories.Chat;
using Solidarize.Domain.Models.Chat;

namespace Solidarize
{
    public class RegisterCompany
    {
        private HttpRequestValidator httpRequestValidator {get;set;}
        private readonly IChatRepository chatRepository;
        public RegisterCompany(HttpRequestValidator validator, IChatRepository chatRepository)
        {
            validator.AddValidator(new BodyValidator<RegisterCompanyRequest>());
            this.httpRequestValidator = validator;
            this.chatRepository = chatRepository;
        }

        [FunctionName("RegisterCompany")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function,"post", Route = null)] HttpRequest req,
            ILogger log)
        {
            var teste  = new Chat(Guid.NewGuid(), DateTime.Now, "");
            chatRepository.Add(teste);
            var validateHttp = await httpRequestValidator.Validate(req);
            if(!validateHttp.Item1)
            {
                return validateHttp.Item2;
            }
            
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
