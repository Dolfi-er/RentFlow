using FacilityService.DTOs.TypeDTOs;

namespace FacilityService.Services;

public interface ITypeService
{
    Task<Guid> CreateAsync(PostTypeDTO postTypeDTO);
    Task<List<GetTypeDTO>> GetAllAsync();
    Task RemoveAsync(Guid id);
}
