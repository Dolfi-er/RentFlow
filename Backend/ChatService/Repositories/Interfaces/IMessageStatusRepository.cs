using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IMessageStatusRepository
{
    Task<List<MessageStatus>> GetALL();
    Task<MessageStatus?> GetById(Guid id);
    Task<Guid> CreateNessageStatus(MessageStatus messageStatus);
}