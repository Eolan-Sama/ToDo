using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NLayer.Core.DTO;
using NLayer.Core.Models;

namespace NLayer.Service.Services.Authentication.JWT;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _config;
    private DateTime _tokenExpiration;
    public JwtTokenGenerator(IConfiguration config, DateTime tokenExpiration)
    {
        _config = config;
        _tokenExpiration = tokenExpiration;
    }
    public TokenModel GenerateToken(UserDto entity)
    {
        _tokenExpiration = DateTime.UtcNow.AddMinutes(30);

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
    var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Email,entity.Email),
            new Claim(ClaimTypes.Name,$"{entity.FirstName}{entity.LastName}"),
            new Claim(ClaimTypes.NameIdentifier,entity.Id.ToString()),
        };
    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Audience"],
            claims, 
            expires: _tokenExpiration,
            signingCredentials: credentials);
            var TheToken= new JwtSecurityTokenHandler().WriteToken(token);
            entity.JwtToken= TheToken;
            return new TokenModel
            {
                Token = TheToken,
                Expiration = _tokenExpiration
            };

    }

    
}
