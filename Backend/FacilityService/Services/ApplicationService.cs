using FacilityService.DTOs.ApplicationDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly string _baseFileURL;

    public ApplicationService(IApplicationRepository applicationRepository, IConfiguration configuration)
    {
        _applicationRepository = applicationRepository;
        _baseFileURL = configuration["FileEndpointBase"]!;
    }

    public async Task<List<GetApplicationDTO>> GetAllAsync()
    {
        return (await _applicationRepository.GetAllAsync()).Select(a => a.ToDTO(_baseFileURL)).ToList();
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