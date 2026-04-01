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

    public Task<User?> GetUser(Guid id)
    {
        return _context.Users.Include(u => u.UserInfoEntity).AsNoTracking().FirstOrDefaultAsync( u =>u.Id == id);
    }
}