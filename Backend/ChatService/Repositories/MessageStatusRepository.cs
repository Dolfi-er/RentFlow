using Backend.Models;
using Backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories;

public class MessageStatusRepository : IMessageStatusRepository
{
    private readonly Context _context;
    public MessageStatusRepository(Context context)
    {
        _context = context;
    }
    public async Task<Guid> CreateNessageStatus(MessageStatus messageStatus)
    {
        await _context.MessagesStatuses.AddAsync(messageStatus);
        await _context.SaveChangesAsync();
        return messageStatus.Id;
    }

    public Task<List<MessageStatus>> GetALL()
    {
        return  _context.MessagesStatuses.AsNoTracking().ToListAsync();
    }

    public Task<MessageStatus?> GetById(Guid id)
    {
        return _context.MessagesStatuses.AsNoTracking().FirstOrDefaultAsync(ms => ms.Id == id);
    }
}