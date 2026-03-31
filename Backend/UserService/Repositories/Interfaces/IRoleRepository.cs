using Backend.DTOs;
using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IRoleRepository
{
    Task<List<Role>> GetALL();
    Task<Guid> CreateRole(Role role);
}