using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Solidarize.Api.Authorization;
using Solidarize.Api.Interface;

namespace Solidarize.Api.Validator.Http;

public class AuthorizationValidator : IHttpRequestValidator
{
    public List<string> Rules {get; set;} = new();
    public AuthorizationValidator(List<string> rules)
    {
        Rules = rules;
    }
    public AuthorizationValidator(){}

    public async Task<(bool, IActionResult?)> Validate(HttpRequest request)
    {
        try
        {
            if (!request.Headers.ContainsKey("Authorization"))
            {
                return (false, new UnauthorizedObjectResult("The request does not contain the Authorization header"));
            }

            string authorizationHeaderValue = request.Headers["Authorization"];

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters().AddJwtSecurityTokenHandlerParameters();
            
            ClaimsPrincipal claimsPrincipal;
                try
                {
                    claimsPrincipal = tokenHandler.ValidateToken(authorizationHeaderValue, validationParameters, out SecurityToken validatedToken);
                }
                catch (SecurityTokenException e)
                {
                    return (false, new UnauthorizedObjectResult($"There was a problem with user authentication. {e.Message}"));
                }

                if (claimsPrincipal.Identity?.IsAuthenticated != true)
                {
                    return (false, new UnauthorizedObjectResult($"The token is not a Valid Token"));
                }
                var Result = new Tuple<bool,IActionResult?>(true,null);
                foreach(var Rule in Rules)
                {
                   if(!claimsPrincipal.HasClaim(e=>e.Type =="User_Rule"))
                   {
                    Result = new Tuple<bool, IActionResult?>(false,new UnauthorizedObjectResult("The token does not contain the User_Rule claim"));
                    break;
                   }
                   var TokenRule = claimsPrincipal.Claims.First(e=>e.Type=="User_Rule");
                   if(!TokenRule.Equals(Rule))
                   {
                    Result = new Tuple<bool, IActionResult?>(false,new ForbidResult());
                   }
                   else
                   {
                    Result = new Tuple<bool,IActionResult?>(true,null);
                    break;
                   }
                }

            return (Result.Item1,Result.Item2);
        }
        catch
        {
            return (false, new InternalServerErrorResult());
        }
    }
}
