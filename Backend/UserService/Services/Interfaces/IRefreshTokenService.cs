using Backend.Models.Entities;

namespace Backend.Services;

public interface IRefreshTokenService
{
    Task<string> CreateToken(User user);
    Task<bool> IsTokenValid(string token, Guid id);
    Task<bool> DeleteToken(string token, Guid id);
}