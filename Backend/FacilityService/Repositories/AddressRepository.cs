using FacilityService.Models;
using FacilityService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace FacilityService.Repositories;

public class AddressRepository : IAddressRepository
{
    private readonly Context _context;

    public AddressRepository(Context context)
    {
        _context = context;
    }

    public async Task<AddressEntity?> GetByIdAsync(Guid addressId)
    {
        return await _context.Addresses.AsNoTracking().FirstOrDefaultAsync(a => a.Id == addressId);
    }

    public async Task<List<AddressEntity>> GetAllAsync()
    {
        return await _context.Addresses.AsNoTracking().ToListAsync();
    }

    public async Task<Guid> CreateAsync(AddressEntity addressEntity)
    {
        await _context.Addresses.AddAsync(addressEntity);
        await _context.SaveChangesAsync();
        return addressEntity.Id;
    }

    public async Task<bool> UpdateAsync(AddressEntity addressEntity)
    {
        AddressEntity? addressEntityFound = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressEntity.Id);
        if (addressEntityFound == null) return false;

        _context.Addresses.Entry(addressEntityFound).CurrentValues.SetValues(addressEntity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task RemoveAsync(Guid addressId)
    {
        AddressEntity? addressEntity = await _context.Addresses.FirstOrDefaultAsync(a => a.Id == addressId);

        if (addressEntity is null) return;

        _context.Addresses.Remove(addressEntity);
        await _context.SaveChangesAsync();
    }
}