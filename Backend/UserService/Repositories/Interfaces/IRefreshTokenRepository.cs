using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IRefreshTokenRepository
{
    Task CreateToken(RefreshToken refreshToken);
    Task<RefreshToken?> GetToken(Guid id);
    Task DeleteToken(RefreshToken refreshToken);
}
