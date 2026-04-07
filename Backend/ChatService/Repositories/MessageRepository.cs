using Backend.Models;
using Backend.Models.Entities;
using MongoDB.Driver.Linq;

namespace Backend.Repositories;

public class MessageRepository : IMessageRepository
{
    private readonly Context _context;
    public MessageRepository(Context context)
    {
        _context = context;
    }

    public async Task<Guid> CreateMessage(Message message, List<Application> applications)
    {
        await _context.Messages.AddAsync(message);
        await _context.Entities.AddRangeAsync(applications);
        await _context.SaveChangesAsync();
        return message.Id;
    }

    public Task<Message?> GetById(Guid id)
    {
        return _context.Messages.FirstOrDefaultAsync(m =>m.Id == id)!;
    }

    public Task UpdateChanges(Message message)
    {
        return _context.SaveChangesAsync();
    }
}