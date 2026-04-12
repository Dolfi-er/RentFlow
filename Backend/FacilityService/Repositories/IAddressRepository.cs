using FacilityService.Models.Entities;

namespace FacilityService.Repositories;

public interface IAddressRepository
{
    Task<Guid> CreateAsync(AddressEntity addressEntity);
    Task<List<AddressEntity>> GetAllAsync();
    Task<AddressEntity?> GetByIdAsync(Guid addressId);
    Task RemoveAsync(Guid addressId);
    Task<bool> UpdateAsync(AddressEntity addressEntity);
    Task<bool> SaveChangesAsync();
}
