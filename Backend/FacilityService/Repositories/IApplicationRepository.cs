using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface IApplicationRepository
{
    Task<Guid> CreateAsync(ApplicationEntity applicationEntity);
    Task<List<ApplicationEntity>> GetAllAsync();
    Task RemoveAsync(Guid applicationId);
}
