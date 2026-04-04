using FacilityService.DTOs.FacilityDTOs;

namespace FacilityService.Services;

public interface IFacilityService
{
    Task<Guid> CreateAsync(PostFacilityDTO postFacilityDTO, Guid ownerId);
    Task<List<GetFacilityDTO>> GetAllAsync();
    Task<GetFacilityDTO?> GetByIdAsync(Guid facilityId);
    Task RemoveAsync(Guid facilityId);
    Task<bool> UpdateAsync(Guid updateFacilityId, Guid ownerId, PutFacilityDTO putFacilityDTO);
}
