using FacilityService.DTOs.FacilityDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class FacilityExtensions
{
    public static GetFacilityDTO ToDTO(this FacilityEntity facilityEntity)
    {
        return new GetFacilityDTO()
        {
            Id = facilityEntity.Id,
            TypeName = facilityEntity.Type?.Name ?? "Неизвестно",
            Name = facilityEntity.Name,
            Description = facilityEntity.Description,
            RentPrice = facilityEntity.Price,
            OwnerId = facilityEntity.OwnerId,
        };
    }

    public static FacilityEntity ToEntity(this PostFacilityDTO postFacilityDTO, Guid ownerId)
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
}