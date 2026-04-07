using FacilityService.DTOs.ApplicationDTOs;

namespace FacilityService.Services;

public interface IApplicationService
{
    Task<Guid> CreateAsync(PostApplicationDTO postApplicationDTO);
    Task<List<GetApplicationDTO>> GetAllAsync();
    Task RemoveAsync(Guid id);
}
