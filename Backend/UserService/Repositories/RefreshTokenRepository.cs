using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RefreshTokenRepository : IRefreshTokenRepository
{
    private readonly Context _context;
    public RefreshTokenRepository(Context context)
    {
        _context = context;
    }

    public async Task CreateToken(RefreshToken refreshToken)
    {
        await _context.RefreshTokens.AddAsync(refreshToken);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteToken(RefreshToken refreshToken)
    {
        _context.RefreshTokens.Remove(refreshToken);
        await _context.SaveChangesAsync();
    }

    public async Task<RefreshToken?> GetToken(Guid id)
    {
        return await GetInstances().FirstOrDefaultAsync(rt => rt.Id == id);
    }

    private IQueryable<RefreshToken> GetInstances()
    {
        return _context.RefreshTokens.Include(rt => rt.UserEntity);
    }
    
}