using Backend.Models.Entities;

namespace Backend.Services;

public interface IJwtService
{
    string GenerateToken(User user);
    string GetCookieName();
    int GetExpireMinutes();
}