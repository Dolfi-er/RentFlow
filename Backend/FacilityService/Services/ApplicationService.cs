using FacilityService.DTOs.ApplicationDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;

    public ApplicationService(IApplicationRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    public async Task<List<GetApplicationDTO>> GetAllAsync()
    {
        return (await _applicationRepository.GetAllAsync()).Select(a => a.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostApplicationDTO postApplicationDTO)
    {
        return await _applicationRepository.CreateAsync(postApplicationDTO.ToEntity());
    }

    public async Task RemoveAsync(Guid id)
    {
        await _applicationRepository.RemoveAsync(id);
    }
}