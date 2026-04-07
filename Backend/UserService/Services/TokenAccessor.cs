
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Backend.Services;

public class TokenAccessor : ITokenAccessor
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public TokenAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? GetUserId()
    {
        var header = _httpContextAccessor.HttpContext?
                .Request.Headers["X-User-Id"]
                .FirstOrDefault();

        return Guid.TryParse(header, out var id) ? id : null; 
    }
}