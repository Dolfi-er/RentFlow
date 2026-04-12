using System.Text;
using FacilityService.DTOs.FacilityDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class FacilityExtensions
{
    public static GetFacilityDTO ToDTO(this FacilityEntity facilityEntity, string baseFileURL)
    {
        return new GetFacilityDTO()
        {
            Id = facilityEntity.Id,
            TypeName = facilityEntity.Type?.Name ?? "Неизвестно",
            Name = facilityEntity.Name,
            Description = facilityEntity.Description,
            RentPrice = facilityEntity.Price,
            OwnerId = facilityEntity.OwnerId,
            RentStatus = facilityEntity.RenterId is null ? "Не сдаётся" : "Сдаётся",

            Town = facilityEntity.Address?.Town ?? "Город",
            Street = facilityEntity.Address?.Street ?? "Улица",
            HouseNumber = facilityEntity.Address?.HouseNumber ?? 0,
            Floor = facilityEntity.Address?.Floor ?? 0,
            Apartment = facilityEntity.Address?.Apartment ?? 0,
            Entrance = facilityEntity.Address?.Entrance ?? 0,

            Applications = facilityEntity.Applications.Select(a => a.ToDTO(baseFileURL)).ToList(),
        };
    }

    public static FacilityEntity ToEntityFacility(this PostFacilityDTO postFacilityDTO, Guid ownerId)
    {
        return new FacilityEntity()
        {
            TypeId = postFacilityDTO.TypeId,
            Name = postFacilityDTO.Name,
            Description = postFacilityDTO.Description,
            Price = postFacilityDTO.RentPrice,
            OwnerId = ownerId,
        };
    }

    public static AddressEntity ToEntityAddress(this PostFacilityDTO postFacilityDTO)
    {
        return new AddressEntity()
        {
            Town = postFacilityDTO.Town,
            Street = postFacilityDTO.Street,
            HouseNumber = postFacilityDTO.HouseNumber,
            Floor = postFacilityDTO.Floor,
            Apartment = postFacilityDTO.Apartment,
            Entrance = postFacilityDTO.Apartment,
        };
    }

    public static FacilityEntity ToEntity(this PutFacilityDTO putFacilityDTO, Guid ownerId, Guid putFacilityId)
    {
        return new FacilityEntity()
        {
            Id = putFacilityId,
            TypeId = putFacilityDTO.TypeId,
            Name = putFacilityDTO.Name,
            Description = putFacilityDTO.Description,
            Price = putFacilityDTO.RentPrice,
            OwnerId = ownerId,
        };
    }

    public static void UpdateEntity(this FacilityEntity facilityEntity, PutFacilityDTO putFacilityDTO)
    {
        facilityEntity.TypeId = putFacilityDTO.TypeId;
        facilityEntity.Name = putFacilityDTO.Name;
        facilityEntity.Description = putFacilityDTO.Description;
        facilityEntity.Price = putFacilityDTO.RentPrice;
    }
}