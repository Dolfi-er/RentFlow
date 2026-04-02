using System.Security.Cryptography;
using Backend.Models.Entities;
using Backend.Repositories;

namespace Backend.Services;
public class RefreshTokenService : IRefreshTokenService
{
    private readonly IHashService _hashService;
    private readonly IRefreshTokenRepository _repository;
    public RefreshTokenService(IHashService hashService, IRefreshTokenRepository repository)
    {
        _hashService = hashService;
        _repository = repository;
    }

    public async Task<string> CreateToken(User user)
    {
        RefreshToken? entity = await _repository.GetToken(user.Id);
        if (entity != null) await _repository.DeleteToken(entity);
        var randomBytes = new byte[64];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomBytes);
        var token = Convert.ToBase64String(randomBytes);
        var hashToken = _hashService.Hash(token);
        var refreshToken = new RefreshToken()
        {
            Id = user.Id,
            HashToken = hashToken,
            ExpiresAt = DateTime.UtcNow.AddDays(10)
        };
        await _repository.CreateToken(refreshToken);
        return token;
    }

    public async Task<bool> DeleteToken(string token, Guid id)
    {
        RefreshToken? refreshToken = await _repository.GetToken(id);
        if (refreshToken is null) return false;
        if (!_hashService.Verify(refreshToken.HashToken, token)) return false;
        if (refreshToken.ExpiresAt < DateTime.UtcNow) return false;
        await _repository.DeleteToken(refreshToken);
        return true;
    }

    public async Task<bool> IsTokenValid(string token, Guid id)
    {
        var RefreshToken = await _repository.GetToken(id);
        if (RefreshToken is null) return false;
        if (!_hashService.Verify(RefreshToken.HashToken, token)) return false;
        if (RefreshToken.ExpiresAt < DateTime.UtcNow) return false;
        return true;
    }
}