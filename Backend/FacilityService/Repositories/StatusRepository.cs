using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class StatusRepository : IStatusRepository
{
    private readonly Context _context;

    public StatusRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<StatusEntity>> GetAllAsync()
    {
        return await _context.Statuses.AsNoTracking().ToListAsync();
    }

    public async Task<Guid> CreateAsync(StatusEntity statusEntity)
    {
        await _context.Statuses.AddAsync(statusEntity);
        await _context.SaveChangesAsync();
        return statusEntity.Id;
    }

    public async Task RemoveAsync(Guid statusId)
    {
        StatusEntity? statusEntity = await _context.Statuses.FirstOrDefaultAsync(s => s.Id == statusId);

        if (statusEntity is null) return;

        _context.Statuses.Remove(statusEntity);
        await _context.SaveChangesAsync();
    }
}