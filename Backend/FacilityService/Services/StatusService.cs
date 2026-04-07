using FacilityService.DTOs.StatusDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class StatusService : IStatusService
{
    private readonly IStatusRepository _statusRepository;

    public StatusService(IStatusRepository statusRepository)
    {
        _statusRepository = statusRepository;
    }

    public async Task<List<GetStatusDTO>> GetAllAsync()
    {
        return (await _statusRepository.GetAllAsync()).Select(s => s.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostStatusDTO postStatusDTO)
    {
        return await _statusRepository.CreateAsync(postStatusDTO.ToEntity());
    }

    public async Task RemoveAsync(Guid id)
    {
        await _statusRepository.RemoveAsync(id);
    }
}