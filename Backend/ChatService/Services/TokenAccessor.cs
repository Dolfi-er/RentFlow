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
         var context = _httpContextAccessor.HttpContext;

        var header = context?.Request.Headers["X-User-Id"].FirstOrDefault();
        if (Guid.TryParse(header, out var id))
            return id;

        var query = context?.Request.Query["userId"].FirstOrDefault();
        if (Guid.TryParse(query, out id))
            return id;

        return null;
    }
}