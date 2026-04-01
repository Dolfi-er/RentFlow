using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IUSerRepository
{
    Task<User?> GetUser(Guid id);
}