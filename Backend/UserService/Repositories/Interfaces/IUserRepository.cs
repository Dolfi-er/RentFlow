using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IUSerRepository
{
    Task<User?> GetUser(Guid id);
    Task<Guid?> CreateUser(User userEntity, UserInfo userInfoEntity);
    Task<User?> GetUserByLogin(string login);
    Task<List<User>> GetAllUsers();
    Task UpdateUser(User user, string newPassword);
    Task Update();
}