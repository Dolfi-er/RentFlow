using FacilityService.DTOs;
using FacilityService.DTOs.TypeDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class TypeService : ITypeService
{
    private readonly ITypeRepository _typeRepository;

    public TypeService(ITypeRepository typeRepository)
    {
        _typeRepository = typeRepository;
    }

    public async Task<List<GetTypeDTO>> GetAllAsync()
    {
        return (await _typeRepository.GetAllAsync()).Select(t => t.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostTypeDTO postTypeDTO)
    {
        return await _typeRepository.CreateAsync(postTypeDTO.ToEntity());
    }

    public async Task RemoveAsync(Guid id)
    {
        await _typeRepository.RemoveAsync(id);
    }
}