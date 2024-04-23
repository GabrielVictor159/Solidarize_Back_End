
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Solidarize.Api.Interface;
namespace Solidarize.Api.Validator.Http;

public class HttpRequestValidator
{
    private readonly List<IHttpRequestValidator> validators = new List<IHttpRequestValidator>();

    public void AddValidator(IHttpRequestValidator validator)
    {
        validators.Add(validator);
    }

    public async Task<(bool, IActionResult?)> Validate(HttpRequest request)
    {
        foreach (var validator in validators)
        {
            var testeObject = await validator.Validate(request);
            if (!testeObject.Item1)
            {
                return (false, testeObject.Item2);
            }
        }

        return (true,null);
    }
}
