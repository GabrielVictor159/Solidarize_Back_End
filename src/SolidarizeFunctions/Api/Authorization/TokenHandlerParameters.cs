using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace Solidarize.Api.Authorization;

public static class TokenHandlerParameters
{
    public static TokenValidationParameters AddJwtSecurityTokenHandlerParameters(this TokenValidationParameters jwtSecurityTokenHandler)
    {
        return new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWTSECRET")!)),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true, 
            ClockSkew = TimeSpan.Zero
        };
    }
}
