using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;
namespace Backend.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly Context _context;

    public ApplicationRepository(Context context)
    {
        _context = context;
    }

    public async Task<List<Application>> GetByMessageId(Guid messageId)
    {
        return await _context.Entities.AsNoTracking().Where( a => a.MessageId == messageId ).ToListAsync();
    }

    public async Task<Guid> CreateAsync(Application applicationEntity)
    {
        await _context.Entities.AddAsync(applicationEntity);
        await _context.SaveChangesAsync();
        return applicationEntity.Id;
    }

    public async Task RemoveAsync(Application applicationEntity)
    {
        _context.Entities.Remove(applicationEntity);
        await _context.SaveChangesAsync();
    }

    public Task<Application?> GetById(Guid applicationId)
    {
       return _context.Entities.FirstOrDefaultAsync(a => a.Id == applicationId);
    }
}