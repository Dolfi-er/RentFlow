using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class UserInfoRepository : IUserInfoRepository
{
    private readonly Context _context;
    public UserInfoRepository(Context context)
    {
        _context = context;
    }
    private IQueryable<UserInfo> GetInstances()
    {
        return _context.UserInfos.Include(ui => ui.UserEntity);
    }
    public Task<UserInfo?> GetUserInfo(Guid id)
    {
        return GetInstances().FirstOrDefaultAsync(ui => ui.Id == id);
    }

    public Task UpdateUserInfo(UserInfo userInfo)
    {
        return _context.SaveChangesAsync();
    }
}