using Backend.DTOs;
using Backend.Models;
using Backend.Models.Entities;
using Backend.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services;

public class ChatRepository : IChatRepository
{
    private readonly Context _context;
    public ChatRepository(Context context)
    {
        _context = context;
    }
    private IQueryable<Chat> GetInstances(Guid userId)
    {
        return _context.Chats.Include(c => c.ChatUsersEntities).Where(c => c.ChatUsersEntities.Any(cu => cu.UserId == userId));
    }
    public Task<List<Chat>> GetAll(Guid userId)
    {
        return GetInstances(userId).AsNoTracking().ToListAsync();
    }

    public Task<List<Chat>> GetAllByFacilityId(Guid facilityId, Guid userId)
    {
        return GetInstances(userId).AsNoTracking().Where(c => c.FacilityId == facilityId).ToListAsync();
    }

    public Task<Chat?> GetById(Guid userId, Guid chatId)
    {
        return GetInstances(userId).AsNoTracking().Include(c => c.MessageEntities).ThenInclude(m => m.MessageStatusEntity).Include(c => c.MessageEntities).ThenInclude(m => m.ApllicationEntities).FirstOrDefaultAsync(c => c.Id ==chatId);
    }

    public async Task<Guid> CreateChat(Chat chat, List<ChatUser> chatUsers)
    {
        await _context.Chats.AddAsync(chat);
        await _context.ChatUsers.AddRangeAsync(chatUsers);
        await _context.SaveChangesAsync();
        return chat.Id;
    }
}