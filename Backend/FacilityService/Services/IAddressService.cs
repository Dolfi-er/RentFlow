using FacilityService.DTOs.AddressDTOs;

namespace FacilityService.Services;

public interface IAddressService
{
    Task<Guid> CreateAsync(PostAddressDTO postAddressDTO);
    Task<List<GetAddressDTO>> GetAllAsync();
    Task<GetAddressDTO?> GetByIdAsync(Guid addressId);
    Task RemoveAsync(Guid addressId);
    Task<bool> UpdateAsync(Guid updateAddressId, PutAddressDTO putAddressDTO);
}
