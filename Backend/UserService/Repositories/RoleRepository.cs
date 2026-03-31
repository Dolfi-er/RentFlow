using Backend.DTOs;
using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly Context _context;
    public RoleRepository(Context context)
    {
        _context = context;
    }

    public async Task<Guid> CreateRole(Role role)
    {
        await _context.Roles.AddAsync(role);
        await _context.SaveChangesAsync();
        return role.Id;
    }

    public async Task<List<Role>> GetALL()
    {
        return await _context.Roles.AsNoTracking().ToListAsync();
    }
}