using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface IStatusRepository
{
    Task<Guid> CreateAsync(StatusEntity statusEntity);
    Task<List<StatusEntity>> GetAllAsync();
    Task RemoveAsync(Guid statusId);
}
