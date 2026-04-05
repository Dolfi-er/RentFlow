using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface IFacilityRepository
{
    Task<Guid> CreateAsync(FacilityEntity facilityEntity);
    Task<List<FacilityEntity>> GetAllAsync(Guid? ownerId = null);
    Task<FacilityEntity?> GetByIdAsync(Guid facilityId);
    Task RemoveApplications(FacilityEntity facilityEntity);
    Task RemoveAsync(Guid facilityId);
    Task<bool> SaveChangesAsync();
    Task<bool> UpdateAsync(FacilityEntity facilityEntity);
}
