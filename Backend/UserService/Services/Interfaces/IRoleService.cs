using Backend.DTOs;
using Backend.Share;

namespace Backend.Services;

public interface IRoleService
{
    Task<Result<List<GetRole>>> GetAll();
    Task<Result<Guid>> CreateRole(PostRole postRole);
}