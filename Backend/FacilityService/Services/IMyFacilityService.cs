using FacilityService.DTOs.FacilityDTOs;

namespace FacilityService.Services;

public interface IMyFacilityService
{
    Task<bool> AppointRenter(Guid facilityId, Guid renterId);
    Task<Guid> CreateAsync(PostFacilityDTO postFacilityDTO, Guid ownerId);
    Task<List<GetFacilityDTO>> GetAllAsync();
    Task<GetFacilityDTO?> GetByIdAsync(Guid facilityId);
    Task<List<GetFacilityDTO>> GetByOwnerAsync(Guid ownerId);
    Task RemoveAsync(Guid facilityId);
    Task RemoveRenter(Guid facilityId);
    Task<bool> UpdateAsync(Guid updateFacilityId, Guid ownerId, PutFacilityDTO putFacilityDTO);
}
