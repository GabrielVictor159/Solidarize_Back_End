using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Solidarize.Api.Interface;

public interface IHttpRequestValidator
{
    Task<(bool, IActionResult?,List<Claim> Claims)> Validate(HttpRequest request);
}
