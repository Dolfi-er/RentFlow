using FacilityService.DTOs.AddressDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class AddressesExtensions
{
    public static GetAddressDTO ToDTO(this AddressEntity addressEntity)
    {
        return new GetAddressDTO()
        {
            Id = addressEntity.Id,
            Town = addressEntity.Town,
            Street = addressEntity.Street,
            HouseNumber = addressEntity.HouseNumber,
            Floor = addressEntity.Floor,
            Apartment = addressEntity.Apartment,
            Entrance = addressEntity.Apartment,
        };
    }

    public static AddressEntity ToEntity(this PostAddressDTO postAddressDTO)
    {
        return new AddressEntity()
        {
            Town = postAddressDTO.Town,
            Street = postAddressDTO.Street,
            HouseNumber = postAddressDTO.HouseNumber,
            Floor = postAddressDTO.Floor,
            Apartment = postAddressDTO.Apartment,
            Entrance = postAddressDTO.Apartment,
        };
    }

    public static AddressEntity ToEntity(this PutAddressDTO putAddressDTO, Guid putAddressId)
    {
        return new AddressEntity()
        {
            Id = putAddressId,
            Town = putAddressDTO.Town,
            Street = putAddressDTO.Street,
            HouseNumber = putAddressDTO.HouseNumber,
            Floor = putAddressDTO.Floor,
            Apartment = putAddressDTO.Apartment,
            Entrance = putAddressDTO.Apartment,
        };
    }
}