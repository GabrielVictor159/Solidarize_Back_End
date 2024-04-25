using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Solidarize.Api.Interface;

namespace Solidarize.Api.Validator.Http;

public class BodyValidator<T> : IHttpRequestValidator
{
    public async Task<(bool, IActionResult?)> Validate(HttpRequest request)
{
    try
    {
        var requestBody = await new StreamReader(request.Body).ReadToEndAsync();
        var serializerSettings = new Newtonsoft.Json.JsonSerializerSettings
        {
            MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Error
        };

        var requestBodyObject = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(requestBody, serializerSettings);

        var validationResults = new List<ValidationResult>();
        var validationContext = new ValidationContext(requestBodyObject);
        var isValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(requestBodyObject, validationContext, validationResults);

        if (!isValid)
        {
            return (false, new BadRequestObjectResult(validationResults));
        }
        else
        {
            return (true, null);
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        return (false, new BadRequestObjectResult(e.Message));
    }
}



}
