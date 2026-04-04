using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class FacilityRepository : IFacilityRepository
{
    private readonly Context _context;

    public FacilityRepository(Context context)
    {
        _context = context;
    }

    public async Task<FacilityEntity?> GetByIdAsync(Guid facilityId)
    {
        return await _context.Facilities.Include(f => f.Type)
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(a => a.Id == facilityId);
    }

    public async Task<List<FacilityEntity>> GetAllAsync()
    {
        return await _context.Facilities.Include(f => f.Type)
                                        .AsNoTracking()
                                        .ToListAsync();
    }

    public async Task<Guid> CreateAsync(FacilityEntity facilityEntity)
    {
        await _context.Facilities.AddAsync(facilityEntity);
        await _context.SaveChangesAsync();
        return facilityEntity.Id;
    }

    public async Task<bool> UpdateAsync(FacilityEntity facilityEntity)
    {
        FacilityEntity? facilityEntityFound = await _context.Facilities.FirstOrDefaultAsync(a => a.Id == facilityEntity.Id);
        if (facilityEntityFound == null) return false;

        _context.Facilities.Entry(facilityEntityFound).CurrentValues.SetValues(facilityEntity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task RemoveAsync(Guid facilityId)
    {
        FacilityEntity? facilityEntity = await _context.Facilities.FirstOrDefaultAsync(a => a.Id == facilityId);

        if (facilityEntity is null) return;

        _context.Facilities.Remove(facilityEntity);
        await _context.SaveChangesAsync();
    }
}