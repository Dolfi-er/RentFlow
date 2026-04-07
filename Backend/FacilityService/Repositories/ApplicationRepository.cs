using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly Context _context;

    public ApplicationRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<ApplicationEntity>> GetAllAsync()
    {
        return await _context.Applications.AsNoTracking().ToListAsync();
    }

    public async Task<Guid> CreateAsync(ApplicationEntity applicationEntity)
    {
        await _context.Applications.AddAsync(applicationEntity);
        await _context.SaveChangesAsync();
        return applicationEntity.Id;
    }

    public async Task RemoveAsync(Guid applicationId)
    {
        ApplicationEntity? applicationEntity = await _context.Applications.FirstOrDefaultAsync(a => a.Id == applicationId);

        if (applicationEntity is null) return;

        _context.Applications.Remove(applicationEntity);
        await _context.SaveChangesAsync();
    }
}