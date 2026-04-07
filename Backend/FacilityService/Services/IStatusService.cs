using FacilityService.DTOs.StatusDTOs;

namespace FacilityService.Services;

public interface IStatusService
{
    Task<Guid> CreateAsync(PostStatusDTO postStatusDTO);
    Task<List<GetStatusDTO>> GetAllAsync();
    Task RemoveAsync(Guid id);
}
