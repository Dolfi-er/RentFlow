using FacilityService.DTOs.TypeDTOs;
using FacilityService.Models.Entities;

namespace FacilityService.Extensions.ExtensionsDTO;

public static class TypeExtensions
{
    public static GetTypeDTO ToDTO(this TypeEntity typeEntity)
    {
        return new GetTypeDTO()
        {
            Id = typeEntity.Id,
            Name = typeEntity.Name,
        };
    }

    public static TypeEntity ToEntity(this PostTypeDTO postTypeDTO)
    {
        return new TypeEntity()
        {
            Name = postTypeDTO.Name,
        };
    }
}