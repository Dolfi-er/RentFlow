using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface ICategoryRepository
{
    Task<Guid> CreateAsync(CategoryEntity categoryEntity);
    Task<List<CategoryEntity>> GetAllAsync();
    Task RemoveAsync(Guid categoryId);
}
