using FacilityService.DTOs.FacilityDTOs;

namespace FacilityService.Services;

public interface IMyFacilityService
{
    Task<Guid> CreateAsync(PostFacilityDTO postFacilityDTO, Guid ownerId);
    Task<List<GetFacilityDTO>> GetAllAsync();
    Task<GetFacilityDTO?> GetByIdAsync(Guid facilityId);
    Task<List<GetFacilityDTO>> GetByOwnerAsync(Guid ownerId);
    Task RemoveAsync(Guid facilityId);
    Task<bool> UpdateAsync(Guid updateFacilityId, Guid ownerId, PutFacilityDTO putFacilityDTO);
}
