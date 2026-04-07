using System.Text;
using Microsoft.Extensions.Options;
using System.Security.Claims;

using Backend.Models;
using Backend.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace Backend.Services;

public class JwtService : IJwtService
{
    private readonly string _SecretKey;
    private readonly int _ExpireMinutes;
    private readonly string _Issuer;
    private readonly string _Audience;
    private readonly string _CookieName;

    public JwtService(IOptions<JwtSettings> jwtSettings)
    {
        var settings = jwtSettings.Value;
        _SecretKey = settings.SecretKey;
        _ExpireMinutes = settings.ExpireMinutes;
        _Issuer = settings.Issuer;
        _Audience = settings.Audience;
        _CookieName = settings.CookieName;
    }

    public string GenerateToken(User user)
    {
        var claims =new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString() )
        };
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_SecretKey)),
        SecurityAlgorithms.HmacSha256);

        var Token =new JwtSecurityToken(
            issuer: _Issuer,
            audience: _Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_ExpireMinutes),
            signingCredentials: signingCredentials
        );

        var TokenValue = new JwtSecurityTokenHandler().WriteToken(Token);
        return TokenValue;
    }

    public string GetCookieName()
    {
        return _CookieName;
    }

    public int GetExpireMinutes()
    {
        return _ExpireMinutes;
    }
}