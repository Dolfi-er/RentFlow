using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IMessageRepository
{
    public Task<Guid> CreateMessage(Message message, List<Application> applications);
    public Task UpdateChanges(Message message);
    public Task<Message?> GetById(Guid id);
}