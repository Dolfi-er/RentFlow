using FacilityService.DTOs.CategoryDTOs;

namespace FacilityService.Services;

public interface ICategoryService
{
    Task<Guid> CreateAsync(PostCategoryDTO postCategoryDTO);
    Task<List<GetCategoryDTO>> GetAllAsync();
    Task RemoveAsync(Guid id);
}
