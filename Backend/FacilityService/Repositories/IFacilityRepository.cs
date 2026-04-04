using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface IFacilityRepository
{
    Task<Guid> CreateAsync(FacilityEntity facilityEntity);
    Task<List<FacilityEntity>> GetAllAsync();
    Task<FacilityEntity?> GetByIdAsync(Guid facilityId);
    Task RemoveAsync(Guid facilityId);
    Task<bool> UpdateAsync(FacilityEntity facilityEntity);
}
