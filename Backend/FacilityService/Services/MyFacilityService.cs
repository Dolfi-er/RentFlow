using FacilityService.DTOs.FacilityDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Models.Entities;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class MyFacilityService : IFacilityService
{
    private readonly IFacilityRepository _facilityRepository;

    public MyFacilityService(IFacilityRepository facilityRepository)
    {
        _facilityRepository = facilityRepository;
    }

    public async Task<GetFacilityDTO?> GetByIdAsync(Guid facilityId)
    {
        FacilityEntity? facilityEntity = await _facilityRepository.GetByIdAsync(facilityId);
        if (facilityEntity is null) return null;
        return facilityEntity.ToDTO();
    }

    public async Task<List<GetFacilityDTO>> GetAllAsync()
    {
        return (await _facilityRepository.GetAllAsync()).Select(f => f.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostFacilityDTO postFacilityDTO, Guid ownerId)
    {
        return await _facilityRepository.CreateAsync(postFacilityDTO.ToEntity(ownerId));
    }

    public async Task<bool> UpdateAsync(Guid updateFacilityId, Guid ownerId, PutFacilityDTO putFacilityDTO)
    {
        return await _facilityRepository.UpdateAsync(putFacilityDTO.ToEntity(ownerId, updateFacilityId));
    }

    public async Task RemoveAsync(Guid facilityId)
    {
        await _facilityRepository.RemoveAsync(facilityId);
    }
}