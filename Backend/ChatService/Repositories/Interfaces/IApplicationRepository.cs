

using Backend.Models.Entities;

namespace Backend.Repositories;

public interface IApplicationRepository
{
    Task<Guid> CreateAsync(Application applicationEntity);
    Task<List<Application>> GetByMessageId(Guid messageId);
    Task<Application?> GetById(Guid applicationId); 
    Task RemoveAsync(Application applicationEntity);
}
