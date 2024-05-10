
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Solidarize.Application.Interfaces;
using Solidarize.Application.Interfaces.Services;
namespace Solidarize.Infraestructure.Services;

public class TokenService : ITokenService
{
    public string Generate(string rule)
    {
        var Secret = Environment.GetEnvironmentVariable("JWTSECRET");
        if (Secret == null)
        {
            throw new InvalidOperationException("SECRET environment variable not deified");
        }
        var tokenExpire = Environment.GetEnvironmentVariable("TOKEN_EXPIRES");
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim("User_Rule", rule)
                }),
            Expires = DateTime.UtcNow.AddHours(tokenExpire != null ? int.Parse(tokenExpire) : 8),
            SigningCredentials = new SigningCredentials
            (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenFinal = tokenHandler.WriteToken(token);
        return tokenFinal;
    }
}
