using Backend.DTOs;
using Backend.Extensions;
using Backend.Models.Entities;
using Backend.Repositories;
using Backend.Share;

namespace Backend.Services;

public class RoleService : IRoleService
{
    private readonly IRoleRepository _repository;
    public RoleService(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> CreateRole(PostRole postRole)
    {
        Role role = postRole.ToEntity();
        Guid id =await _repository.CreateRole(role);
        return Result<Guid>.Success(id);
    }

    public async Task<Result<List<GetRole>>> GetAll()
    {
        List<Role> roles = await _repository.GetALL();
        List<GetRole> dtos = new List<GetRole>();
        foreach (var role in roles)
        {
            dtos.Add(role.ToDTO());
        }
        return Result<List<GetRole>>.Success(dtos);
    }
}