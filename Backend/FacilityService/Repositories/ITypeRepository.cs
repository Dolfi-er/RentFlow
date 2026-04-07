using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface ITypeRepository
{
    Task<Guid> CreateAsync(TypeEntity typeEntity);
    Task<List<TypeEntity>> GetAllAsync();
    Task RemoveAsync(Guid typeId);
}
