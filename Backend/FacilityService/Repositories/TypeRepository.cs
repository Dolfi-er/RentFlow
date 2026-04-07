using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class TypeRepository : ITypeRepository
{
    private readonly Context _context;

    public TypeRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<TypeEntity>> GetAllAsync()
    {
        return await _context.Types.AsNoTracking().ToListAsync();
    }

    public async Task<Guid> CreateAsync(TypeEntity typeEntity)
    {
        await _context.Types.AddAsync(typeEntity);
        await _context.SaveChangesAsync();
        return typeEntity.Id;
    }

    public async Task RemoveAsync(Guid typeId)
    {
        TypeEntity? typeEntity = await _context.Types.FirstOrDefaultAsync(t => t.Id == typeId);

        if (typeEntity is null) return;

        _context.Types.Remove(typeEntity);
        await _context.SaveChangesAsync();
    }
}