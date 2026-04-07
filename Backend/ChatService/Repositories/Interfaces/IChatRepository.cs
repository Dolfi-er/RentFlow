using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IChatRepository
{
    Task<List<Chat>> GetAll(Guid userId);
    Task<List<Chat>> GetAllByFacilityId(Guid facilityId, Guid userId);
    Task<Chat?> GetById(Guid userId, Guid chatId);
    Task<Guid> CreateChat(Chat chat, List<ChatUser> chatUsers);
    
}