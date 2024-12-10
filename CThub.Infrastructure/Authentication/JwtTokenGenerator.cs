using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CThub.Application.Common.Authentication;
using CThub.Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using User = CThub.Domain.Models.User;

namespace CThub.Infrastructure.Authentication;

public class JwtTokenGenerator(IOptions<JwtSetting> jwtOptions) : IJwtTokenGenerator
{
    private readonly JwtSetting _jwtOptions = jwtOptions.Value;

    public string GetToken(User user)
    {
        var signingCredential = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret)), SecurityAlgorithms.HmacSha256
            );
        
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };
        
        var token = new JwtSecurityToken(
            claims: claims,
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            
            expires: DateTime.UtcNow.AddMinutes(60),
            signingCredentials: signingCredential   //new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey")), SecurityAlgorithms.HmacSha256)
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}