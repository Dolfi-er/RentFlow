using FacilityService.DTOs.CategoryDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<List<GetCategoryDTO>> GetAllAsync()
    {
        return (await _categoryRepository.GetAllAsync()).Select(c => c.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostCategoryDTO postCategoryDTO)
    {
        return await _categoryRepository.CreateAsync(postCategoryDTO.ToEntity());
    }

    public async Task RemoveAsync(Guid id)
    {
        await _categoryRepository.RemoveAsync(id);
    }
}