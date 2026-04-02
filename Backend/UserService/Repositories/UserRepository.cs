using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserRepository : IUSerRepository
{
    private readonly Context _context;
    public UserRepository(Context context)
    {
        _context = context;
    }
    private IQueryable<User> GetInstances()
    {
        return _context.Users.Include(u => u.UserInfoEntity).Include(u => u.RefreshTokenEntity);
    }
    
    public async Task<Guid?> CreateUser(User userEntity, UserInfo userInfoEntity)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _context.Users.Add(userEntity);
            _context.UserInfos.Add(userInfoEntity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return userEntity.Id;
        }
        catch
        {
            await transaction.RollbackAsync();
            return null;
        }
    }

    public Task<User?> GetUser(Guid id)
    {
        return _context.Users.Include(u => u.UserInfoEntity).AsNoTracking().FirstOrDefaultAsync( u =>u.Id == id);
    }

    public Task<User?> GetUserByLogin(string login)
    {
        return GetInstances().FirstOrDefaultAsync(u => u.Login == login);
    }

    public Task Update()
    {
        return _context.SaveChangesAsync();
    }

    public Task UpdateUser(User user, string newPassword)
    {
        user.HashPassword = newPassword;
        return _context.SaveChangesAsync();
    }

    public Task<List<User>> GetAllUsers()
    {
        return GetInstances().AsNoTracking().ToListAsync();
    }
}