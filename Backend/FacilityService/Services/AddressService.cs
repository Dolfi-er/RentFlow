using FacilityService.DTOs.AddressDTOs;
using FacilityService.Extensions.ExtensionsDTO;
using FacilityService.Models.Entities;
using FacilityService.Repositories;

namespace FacilityService.Services;

public class AddressService : IAddressService
{
    private readonly IAddressRepository _addressRepository;

    public AddressService(IAddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public async Task<GetAddressDTO?> GetByIdAsync(Guid addressId)
    {
        AddressEntity? addressEntity = await _addressRepository.GetByIdAsync(addressId);
        if (addressEntity is null) return null;
        return addressEntity.ToDTO();
    }

    public async Task<List<GetAddressDTO>> GetAllAsync()
    {
        return (await _addressRepository.GetAllAsync()).Select(a => a.ToDTO()).ToList();
    }

    public async Task<Guid> CreateAsync(PostAddressDTO postAddressDTO)
    {
        return await _addressRepository.CreateAsync(postAddressDTO.ToEntity());
    }

    public async Task<bool> UpdateAsync(Guid updateAddressId, PutAddressDTO putAddressDTO)
    {
        return await _addressRepository.UpdateAsync(putAddressDTO.ToEntity(updateAddressId));
    }

    public async Task RemoveAsync(Guid addressId)
    {
        await _addressRepository.RemoveAsync(addressId);
    }
}