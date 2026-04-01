using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IUserInfoRepository
{
    Task<UserInfo?> GetUserInfo(Guid id);
    Task UpdateUserInfo(UserInfo userInfo);
}